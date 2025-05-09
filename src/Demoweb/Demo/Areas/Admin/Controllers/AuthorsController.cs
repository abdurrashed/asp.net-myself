using Demo.Application.Services;
using Demo.Areas.Admin.Models;
using Demo.Domaiin;
using Demo.Domaiin.Entities;
using Demo.Domaiin.Services;
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
        public AuthorsController(ILogger<AuthorsController>logger,IAuthorService authorService)
        {
            _logger = logger;

            _authorService = authorService;
        }



        public IActionResult Index()
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
                _authorService.AddAuthor(new Author { Name= model.Name,Biography=string.Empty,Rating=1.0});

            }

            return View(model);
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
