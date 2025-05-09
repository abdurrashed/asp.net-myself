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



    }
}
