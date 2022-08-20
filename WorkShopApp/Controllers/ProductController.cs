using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShopApp.Models;
using WorkShopApp.Services.Interfaces;

namespace WorkShopApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService,
                                 ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var fetchedProducts = await _productService.GetProducts(1);
            return View(fetchedProducts);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int pageIndex)
        {
            var fetchedProducts = await _productService.GetProducts(pageIndex);
            return View(fetchedProducts);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = new SelectList( await _categoryService.GetCategories(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product productToAdd)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Create));
            try
            {
                var isSaved = await _productService.AddProduct(productToAdd);
                if (!isSaved)
                    return BadRequest("Fail to save product");
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      
    }
}
