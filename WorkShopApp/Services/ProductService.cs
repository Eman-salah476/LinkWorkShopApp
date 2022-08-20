using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShopApp.Dtos;
using WorkShopApp.Models;
using WorkShopApp.Repository.Interfaces;
using WorkShopApp.Services.Interfaces;

namespace WorkShopApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IGenericRepository<Product> genericRepository,
                              IUnitOfWork unitOfWork)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }
      
        
        public async Task<bool> AddProduct(Product product)
        {
            await _genericRepository.Add(product);
            var isSaved = await _unitOfWork.Save();
            return isSaved;
        }

        public async Task<List<Product>> GetProducts(int? categoryId = null)
        {
            if (categoryId == null)
               return  await _genericRepository.GetAll();
            else
               return  await _genericRepository.FindByCondition(p => p.CategoryId == categoryId);
        }

        public ProductModel FilterProducts(List<Product> products, int pageIndex)
        {
            int maxRows = 5;
            var productModel = new ProductModel();

            //Return products of current page
            productModel.Products = products.OrderBy(p => p.Id).Skip((pageIndex - 1) * maxRows).Take(5).ToList();

            //Calculate pages count
            double pageCount = (double)((double)products.Count() / (double)maxRows);
            productModel.PageCount = (int)Math.Ceiling(pageCount);

            productModel.CurrentPageIndex = pageIndex;
            return productModel;
        }

        public async Task<Product> Find(int id)
        {
            var fetchedProduct = await _genericRepository.GetById(id);
            return fetchedProduct;
        }

        public async Task<bool> Update(Product product)
        {
             _genericRepository.Update(product);
            var isUpdated = await _unitOfWork.Save();
            return isUpdated;
        }
    }
}
