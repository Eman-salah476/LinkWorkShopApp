using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkShopApp.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> Save();
    }
}
