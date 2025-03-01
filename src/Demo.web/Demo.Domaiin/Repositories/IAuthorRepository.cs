using Demo.Domaiin.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domaiin.Repositories
{
    public interface IAuthorRepository:IRepository<Author,Guid>
    {


    }
}
