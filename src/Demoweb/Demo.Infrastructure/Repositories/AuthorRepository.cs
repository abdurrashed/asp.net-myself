using Demo.Domaiin;
using Demo.Domaiin.Entities;
using Demo.Domaiin.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Repositories
{
    public class AuthorRepository: Repository<Author, Guid>,IAuthorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AuthorRepository(ApplicationDbContext context)
        :base(context)
        {

            _dbContext = context;
        }

        public (IList<Author> data, int total, int totalDisplay) GetPageAuthors(int pageIndex, int pageSize, string? order, DataTablesSearch search)
        {
            if (string.IsNullOrEmpty(search.Value))
                return GetDynamic(null, order, null, pageIndex, pageSize, true);
            else
                return GetDynamic(x => x.Name.Contains(search.Value), order, null, pageIndex, pageSize, true);

            
            
        }
    }
}
