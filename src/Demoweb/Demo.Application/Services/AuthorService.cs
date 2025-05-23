using Demo.Application.Exceptions;
using Demo.Domaiin;
using Demo.Domaiin.DTOS;
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
            if (!_applicationUnitOfWork1.AuthorRepository.IsNameDuplicate(author.Name))
            {
                _applicationUnitOfWork1.AuthorRepository.Add(author);
                _applicationUnitOfWork1.Save();
            }
            else
            {
                throw new DuplicateAuthorNameException();
            }
          
            
        }

        public void DeleteAuthor(Guid id)
        {

            _applicationUnitOfWork1.AuthorRepository.Remove(id);
            _applicationUnitOfWork1.Save();
           
        }

        public Author GetAuthor(Guid id)
        {
            return _applicationUnitOfWork1.AuthorRepository.GetById(id);
        }

        public (IList<Author> data, int total, int totalDisplay) GetAuthors(int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            return _applicationUnitOfWork1.AuthorRepository.GetPageAuthors(pageIndex, pageSize, order, search);
        }

        public async Task<(IList<Author> data, int total, int totalDisplay)> GetAuthorsSP(int pageIndex,
             int pageSize, string? order, AuthorSearchDto search)
        {
            return await _applicationUnitOfWork1.GetAuthorsSP(pageIndex, pageSize, order, search);
        }

        public void UpdateAuthor(Author author)
        {
            _applicationUnitOfWork1.AuthorRepository.Edit(author);
            _applicationUnitOfWork1.Save();
        }
    }
}
