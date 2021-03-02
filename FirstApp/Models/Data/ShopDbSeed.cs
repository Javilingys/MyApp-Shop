using FirstApp.Models.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Models.Data
{
    public class ShopDbSeed
    {
        public static async Task SeedDataAsyn(ShopDbContext context)
        {
            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Product 1",
                    Description = "This is Product's 1 Description",
                    Price = 10m
                },
                new Product
                {
                    Name = "Product 2",
                    Description = "This is Product's 2 Description",
                    Price = 20m
                },
                new Product
                {
                    Name = "Product 3",
                    Description = "This is Product's 3 Description",
                    Price = 10m
                },
                new Product
                {
                    Name = "Product 4",
                    Description = "This is Product's 4 Description",
                    Price = 20m
                },
                new Product
                {
                    Name = "Product 5",
                    Description = "This is Product's 5 Description",
                    Price = 10m
                },
                new Product
                {
                    Name = "Product 6",
                    Description = "This is Product's 6 Description",
                    Price = 20m
                },
                new Product
                {
                    Name = "Product 7",
                    Description = "This is Product's 7 Description",
                    Price = 10m
                },
                new Product
                {
                    Name = "Product 8",
                    Description = "This is Product's 8 Description",
                    Price = 20m
                },
                new Product
                {
                    Name = "Product 9",
                    Description = "This is Product's 9 Description",
                    Price = 10m
                },
                new Product
                {
                    Name = "Product 10",
                    Description = "This is Product's 10 Description",
                    Price = 20m
                }
            };

            await context.Products.AddRangeAsync(products);
            await context.SaveChangesAsync();
        }
    }
}
