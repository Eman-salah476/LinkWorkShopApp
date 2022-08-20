using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShopApp.Data;
using WorkShopApp.Models;
using WorkShopApp.Repository.Interfaces;

namespace WorkShopApp.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public Task AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();

        }

     




    }
}
