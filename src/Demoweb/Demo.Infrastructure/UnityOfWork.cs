using Demo.Domaiin.Repositories;
using Demo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure
{
    public abstract class UnityOfWork : IUnityOfWork
    {

        private readonly DbContext _dbContext;



        public UnityOfWork(DbContext context)
        {
            _dbContext = context;
           

        }

        public async Task SaveAsync()
        {
           await _dbContext.SaveChangesAsync();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
