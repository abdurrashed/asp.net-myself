using Demo.Domaiin.DTOS;
using Demo.Domaiin.Entities;
using Demo.Domaiin.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domaiin.Services
{
    public interface IApplicationUnitOfWork:IUnityOfWork
    {

        public IBookRepository BookRepository { get; }
        public IAuthorRepository AuthorRepository { get; }

        Task<(IList<Author> data, int total, int totalDisplay)> GetAuthorsSP(int pageIndex,
                   int pageSize, string? order, AuthorSearchDto search);
    }
}
