using AutoMapper;
using Demo.Application.Exceptions;
using Demo.Application.Services;
using Demo.Areas.Admin.Models;
using Demo.Domaiin;
using Demo.Domaiin.Entities;
using Demo.Domaiin.Services;
using Demo.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using System.Data;
using System.Runtime.CompilerServices;
using System.Web;

namespace Demo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorsController : Controller
    {

        private readonly ILogger<AuthorsController> _logger;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorsController(ILogger<AuthorsController>logger,IAuthorService authorService, IMapper mapper )
        {
            _logger = logger;
            _mapper = mapper;

            _authorService = authorService;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexSP()
        {

            return View();
        }

        public IActionResult Add()
        {

            var model = new AddAuthorModel();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Add(AddAuthorModel model)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    var author = _mapper.Map<Author>(model);
                    author.Id = IdentityGenrator.NewSequentialGuid();
                    _authorService.AddAuthor(author);

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message="Author added",
                        Type=ResponseTypes.Success

        
                    });
                    return RedirectToAction("Index");
                }



                catch (DuplicateAuthorNameException de)
                {



                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = de.Message,
                        Type = ResponseTypes.Danger


                    });


                }




                catch (Exception ex)
                {
                    _logger.LogError(ex, "filed to add author");


                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Failed to Add Author",
                        Type = ResponseTypes.Danger


                    });

                    
                }
               

            }
            return View(model);


        }

        public IActionResult Update(Guid id)
        {

            var model = new UpdateAuthorModel();
            var author = _authorService.GetAuthor(id);
            _mapper.Map(author, model);
            return View(model);


        }

        [HttpPost,ValidateAntiForgeryToken]
        public IActionResult Update(UpdateAuthorModel model)
        {

            if (ModelState.IsValid)
            {

                try
                {

                   

                    var author = _mapper.Map<Author>(model);
                  
                    _authorService.UpdateAuthor(author);

                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Author updated",
                        Type = ResponseTypes.Success


                    });
                    return RedirectToAction("Index");
                }



                catch (DuplicateAuthorNameException de)
                {



                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = de.Message,
                        Type = ResponseTypes.Danger


                    });


                }




                catch (Exception ex)
                {
                    _logger.LogError(ex, "filed to add author");


                    TempData.Put("ResponseMessage", new ResponseModel
                    {
                        Message = "Failed to Add Author",
                        Type = ResponseTypes.Danger


                    });


                }


            }

            return View(model);


        }

        [HttpPost,ValidateAntiForgeryToken]

        public IActionResult Delete(Guid id)
        {

            try
            {
                _authorService.DeleteAuthor(id);
                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Author deleted",
                    Type = ResponseTypes.Success


                });
               





            }
            catch(Exception ex)
            {

                TempData.Put("ResponseMessage", new ResponseModel
                {
                    Message = "Failed to delete Author",
                    Type = ResponseTypes.Danger


                });

            }
            return RedirectToAction("Index");

        }












        public JsonResult GetAuthorJsonData([FromBody]AuthorListModel model)
        {
            try
            {

                var result = _authorService.GetAuthors(model.PageIndex, model.PageSize, model.FormatSortExpression("Name", "Biography", "Rating","Id" ), model.Search);

                var authors = new
                {
                    recordsTotal = result.total,
                    recordsFiltered = result.totalDisplay,
                    data = (from record in result.data
                            select new string[]
                            {
                              HttpUtility.HtmlEncode(record.Name),
                              HttpUtility.HtmlEncode(record.Biography),
                            record.Rating.ToString(),
                            record.Id.ToString()
                            }).ToArray()



                };
                return Json(authors);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "There was a problem in getting authors");

                return Json(DataTables.EmptyResult);

            }

        }





    }
}
