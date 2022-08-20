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
            //Seed categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "TVs" },
                new Category { Id = 2, Name = "LapTops" },
                new Category { Id = 3, Name = "Sound Systems" }
                );

            //Seed some products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id=1, Name="Lab Top Dell", Description="New laptop from Dell Ram 16, Core I7", Price=10000, Quantity=5, Discount=0, CategoryId=2},
                new Product { Id=2, Name="TV Samsung", Description="New TV from Samsung high quality", Price=10000, Quantity=5, Discount=10, CategoryId=1},
                new Product { Id=3, Name="Sound System", Description="New sound system", Price=1000, Quantity=5, Discount=0, CategoryId=3}
                );


            //Seed user admin
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
