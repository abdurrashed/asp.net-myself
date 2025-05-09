using Demo.Domaiin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domaiin.Services
{
    public interface IAuthorService
    {

        void AddAuthor(Author author);
        (IList<Author> data,int total, int totalDisplay) GetAuthors(int pageIndex, int pageSize,string? order, DataTablesSearch search);
    }
}
