using Microsoft.EntityFrameworkCore;
using System;
using WorkShopApp.Models;
using WorkShopApp.Models.Enums;

namespace WorkShopApp.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "TVs" },
                new Category { Id = 2, Name = "LapTops" },
                new Category { Id = 3, Name = "Sound Systems" }
                );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin",
                    Phone = "01100903127",
                    Email = "admin@gmail.com",
                    Password = "admin",
                    Address = "Cairo",
                    Role = Role.Admin,
                    CreatedAt = DateTime.Now
                });
        }
    }
}
