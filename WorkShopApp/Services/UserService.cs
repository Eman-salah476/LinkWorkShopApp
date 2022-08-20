using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkShopApp.Models;
using WorkShopApp.Models.Enums;
using WorkShopApp.Repository.Interfaces;
using WorkShopApp.Services.Interfaces;

namespace WorkShopApp.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _genericRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserService(IGenericRepository<User> genericRepository,
                              IUnitOfWork unitOfWork,
                              IHttpContextAccessor httpContextAccessor)
        {
            _genericRepository = genericRepository;
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }
     
        
        
        public async Task<User> RegisterUser(User user)
        {
            user.Role = Role.User;
            var savedUser = await _genericRepository.Add(user);
            var isSaved = await _unitOfWork.Save();
            if (isSaved)
                return user;
            else
                return null;
        }

        public ClaimsPrincipal CreateIdentity(int id, string name)
        {
            try
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, Convert.ToString(id)),
                new Claim(ClaimTypes.Name, name)
            };
                //Initialize a new instance of the ClaimsIdentity with the claims and authentication scheme    
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                //Initialize a new instance of the ClaimsPrincipal with ClaimsIdentity    
                return new ClaimsPrincipal(identity);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string FetchUserID()
        {
            var claims = _httpContextAccessor.HttpContext.User.Claims.ToList();
            if (claims.Count != 0)
                return claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            else
                return null;
            //return _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        }

    }
}
