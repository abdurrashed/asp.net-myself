using Demo.Domaiin.Entities;
using Demo.Domaiin.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Services
{
    public class AuthorService:IAuthorService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork1;
        public AuthorService(IApplicationUnitOfWork applicationUnitOfWork)
        {
            _applicationUnitOfWork1 = applicationUnitOfWork;

        }

        public void AddAuthor(Author author)
        {
            _applicationUnitOfWork1.AuthorRepository.Add(author);
            _applicationUnitOfWork1.Save();
        }




    }
}
