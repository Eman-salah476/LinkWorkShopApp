using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShopApp.Models;

namespace WorkShopApp.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<List<Product>> GetProducts();
    }
}
