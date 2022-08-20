using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShopApp.Models;
using WorkShopApp.Services.Interfaces;

namespace WorkShopApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        private readonly IUserService _userService;
        public OrderController(IOrderService orderService,
                               IProductService productService,
                               IUserService userService)
        {
            _orderService = orderService;
            _productService = productService;
            _userService = userService;
        }


        public async Task<IActionResult> Order(int productId)
        {
            //Check user cookie 
            var fetchedUserId = _userService.FetchUserID();
            if (fetchedUserId == null)
                return RedirectToAction("Create", "User");

            //check Product availability
            var fetchedProduct = await _productService.Find(productId);
            if (fetchedProduct == null)
                return NotFound();
            ViewBag.Product = fetchedProduct;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Order(UserProduct userProduct)
        {
            //Check product available quantity and existance
            var fetchedProduct = await _productService.Find(userProduct.ProductId);
            if (fetchedProduct == null || fetchedProduct.Quantity == 0)
                ModelState.AddModelError("", "This product is out of stock");
       
            if(userProduct.Quantity > fetchedProduct.Quantity)
                ModelState.AddModelError("", "You ordered more than quantity in stock");


            if (!ModelState.IsValid)
                return RedirectToAction("Order", new { productId = userProduct.ProductId });
            

            //Fetch user id from cookie
            var fetchedUserId = _userService.FetchUserID();
            if (fetchedProduct != null)
                userProduct.UserId = Convert.ToInt32(fetchedUserId);
            else
                return RedirectToAction("Index", "Product");

            //Add oder in DB
            var isAdded = await _orderService.AddOrder(userProduct);
            if (!isAdded)
                return BadRequest();

            //Update Product Quantity
            fetchedProduct.Quantity = fetchedProduct.Quantity - userProduct.Quantity;
            var isUpdated = await _productService.Update(fetchedProduct);
            if (!isUpdated)
                return BadRequest();

            return RedirectToAction("Index", "Product");
        }


    }
}
