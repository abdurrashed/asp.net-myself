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



    }
}
