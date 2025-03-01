﻿using Demo.Application.Features.Books.Commands;
using Demo.Areas.Admin.Models;
using Demo.Domaiin.Entities;
using Demo.Domaiin.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class BooksController : Controller
    {
        private readonly IMediator _mediator;




        public BooksController(IMediator mediator)
        {

            _mediator = mediator;
        }

       
        public IActionResult Index()
        {
            return View();
        }




        public IActionResult Add()
        {

            var model = new AddBookModel();
            return View(model);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(BookAddCommand bookAddCommand)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(bookAddCommand);

            }

            return View(bookAddCommand);
        }


    }
}
