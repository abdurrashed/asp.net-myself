using Demo.Domaiin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domaiin.Repositories
{
    public interface IAuthorRepository : IRepository<Author, Guid>
    {
        (IList<Author> data, int total, int totalDisplay) GetPageAuthors(int pageIndex, int pageSize, string? order, DataTablesSearch search);
        bool IsNameDuplicate(string name, Guid? id = null);
    }
}
