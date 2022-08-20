using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShopApp.Dtos;
using WorkShopApp.Models;

namespace WorkShopApp.Services.Interfaces
{
    public interface IProductService
    {
        Task<bool> AddProduct(Product product);
        //Task<ProductModel> GetProducts(int pageIndex, int? categoryId = null);
        Task<List<Product>> GetProducts(int? categoryId = null);
        ProductModel FilterProducts(List<Product> products, int pageIndex);
    }
}
