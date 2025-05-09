using Demo.Domaiin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domaiin.Repositories
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
        List<Book> GetLatesBooks();
    }
}
