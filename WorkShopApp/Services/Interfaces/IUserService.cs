using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkShopApp.Models;

namespace WorkShopApp.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> RegisterUser(User user);
        ClaimsPrincipal CreateIdentity(int id, string name);
        string FetchUserID();
    }
}
