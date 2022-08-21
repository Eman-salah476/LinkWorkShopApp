using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            ViewBag.Categories = new SelectList( await _categoryService.GetCategories(), "Id", "Name");
            var fetchedProducts = await _productService.GetProducts();
            var FilteredProducts = _productService.FilterProducts(fetchedProducts, 1);
            return View(FilteredProducts);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int pageIndex, int? categoryId)
        {
            ViewBag.Categories = new SelectList(await _categoryService.GetCategories(), "Id", "Name");
            var fetchedProducts = await _productService.GetProducts(categoryId);
            var FilteredProducts = _productService.FilterProducts(fetchedProducts, pageIndex);
            FilteredProducts.CategoryId = categoryId;
            return View(FilteredProducts);
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
                    return RedirectToAction(nameof(Create));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      
    }
}
