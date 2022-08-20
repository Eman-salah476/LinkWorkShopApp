using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShopApp.Models;
using WorkShopApp.Repository.Interfaces;
using WorkShopApp.Services.Interfaces;

namespace WorkShopApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _categoryRepository; 
        public CategoryService(IGenericRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<Category>> GetCategories()
        {
            return await _categoryRepository.GetAll();
        }
    }
}
