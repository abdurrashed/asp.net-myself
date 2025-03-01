using Demo.Domaiin.Entities;
using Demo.Domaiin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork1;
        public BookService(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork1 = applicationUnitOfWork;

        }

        public void AddBook(Book book)
        {
            _applicationUnitOfWork1.BookRepository.Add(book);
            _applicationUnitOfWork1.Save();
        }
    }
}
