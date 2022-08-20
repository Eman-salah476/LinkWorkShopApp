using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (!ModelState.IsValid)
                return RedirectToAction(nameof(Create));
            try
            {
                var savedUser = await _userService.RegisterUser(user);
                if (savedUser == null)
                    return RedirectToAction(nameof(Create));

                var principal = _userService.CreateIdentity(savedUser.Id, savedUser.FirstName);
                //SignInAsync is a Extension method for Sign in a principal for the specified scheme.    
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                              principal,
                                              new AuthenticationProperties() { IsPersistent = true });


                return RedirectToAction("Index", "Product");
            }
            catch
            {
                return View();
            }
        }

   
 
    }
}
