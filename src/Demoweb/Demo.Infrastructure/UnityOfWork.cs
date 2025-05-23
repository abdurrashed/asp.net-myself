using Demo.Domaiin.Repositories;
using Demo.Domaiin.Utilities;
using Demo.Infrastructure.Repositories;
using Demo.Infrastructure.Utilities;
using Microsoft.Data.SqlClient;
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

        protected ISqlUtility SqlUtility { get; private set; }

        public UnityOfWork(DbContext context)
        {
            _dbContext = context;

            SqlUtility = new SqlUtility(_dbContext.Database.GetDbConnection());

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
