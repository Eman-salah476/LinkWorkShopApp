using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShopApp.Models;

namespace WorkShopApp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategories();
    }
}
