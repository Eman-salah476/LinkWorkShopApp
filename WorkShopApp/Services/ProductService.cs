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
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository<Product> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IProductRepository productRepository,
                              IGenericRepository<Product> genericRepository,
                              IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> AddProduct(Product product)
        {
            await _genericRepository.Add(product);
            var isSaved = await _unitOfWork.Save();
            return isSaved;
        }

        public async Task<ProductModel> GetProducts(int pageIndex)
        {
            int maxRows = 5;
            //Fetch all Products
            var fetchedProducts = await _productRepository.GetProducts();

            var productModel = new ProductModel();
            
            //Return products of current page
            productModel.Products = fetchedProducts.OrderBy(p => p.Id).Skip((pageIndex - 1) * maxRows).Take(5).ToList();
           
            //Calculate page count
            double pageCount = (double)((double)fetchedProducts.Count() / (double)maxRows );
            productModel.PageCount = (int)Math.Ceiling(pageCount);

            productModel.CurrentPageIndex = pageIndex;

            return productModel;
        }




    }
}
