using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domaiin.Repositories
{
    public interface IUnityOfWork
    {

        void Save();
        Task SaveAsync();


    }
}
