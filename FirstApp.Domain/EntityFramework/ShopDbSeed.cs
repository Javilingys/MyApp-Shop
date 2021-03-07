
using FirstApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.Domain.EntityFramework
{
    // Seed class
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
                    Price = 10m,
                    PictureUrl = "images/products/sb-ang1.png",
                    ProductTypeId = 1,
                    ProductBrandId = 1
                },
                new Product
                {
                    Name = "Product 2",
                    Description = "This is Product's 2 Description",
                    Price = 20m,
                    PictureUrl = "images/products/sb-ang2.png",
                    ProductTypeId = 1,
                    ProductBrandId = 1
                },
                new Product
                {
                    Name = "Product 3",
                    Description = "This is Product's 3 Description",
                    Price = 30m,
                    PictureUrl = "images/products/sb-core1.png",
                    ProductTypeId = 1,
                    ProductBrandId = 2
                },
                new Product
                {
                    Name = "Product 4",
                    Description = "This is Product's 4 Description",
                    Price = 40m,
                    PictureUrl = "images/products/sb-core2.png",
                    ProductTypeId = 1,
                    ProductBrandId = 2
                },
                new Product
                {
                    Name = "Product 5",
                    Description = "This is Product's 5 Description",
                    Price = 50m,
                    PictureUrl = "images/products/sb-react1.png",
                    ProductTypeId = 1,
                    ProductBrandId = 4
                },
                new Product
                {
                    Name = "Product 6",
                    Description = "This is Product's 6 Description",
                    Price = 60m,
                    PictureUrl = "images/products/sb-ts1.png",
                    ProductTypeId = 1,
                    ProductBrandId = 5
                },
                new Product
                {
                    Name = "Product 7",
                    Description = "This is Product's 7 Description",
                    Price = 70m,
                    PictureUrl = "images/products/hat-core1.png",
                    ProductTypeId = 2,
                    ProductBrandId = 2
                },
                new Product
                {
                    Name = "Product 8",
                    Description = "This is Product's 8 Description",
                    Price = 80m,
                    PictureUrl = "images/products/hat-react1.png",
                    ProductTypeId = 2,
                    ProductBrandId = 4
                },
                new Product
                {
                    Name = "Product 9",
                    Description = "This is Product's 9 Description",
                    Price = 90m,
                    PictureUrl = "images/products/hat-react2.png",
                    ProductTypeId = 2,
                    ProductBrandId = 4
                },
                new Product
                {
                    Name = "Product 10",
                    Description = "This is Product's 10 Description",
                    Price = 100m,
                    PictureUrl = "images/products/glove-code1.png",
                    ProductTypeId = 4,
                    ProductBrandId = 3
                },
                new Product
                {
                    Name = "Product 11",
                    Description = "This is Product's 11 Description",
                    Price = 110m,
                    PictureUrl = "images/products/glove-code2.png",
                    ProductTypeId = 4,
                    ProductBrandId = 3
                },
                new Product
                {
                    Name = "Product 12",
                    Description = "This is Product's 12 Description",
                    Price = 120m,
                    PictureUrl = "images/products/glove-react1.png",
                    ProductTypeId = 4,
                    ProductBrandId = 4
                },
                new Product
                {
                    Name = "Product 13",
                    Description = "This is Product's 13 Description",
                    Price = 130m,
                    PictureUrl = "images/products/glove-react2.png",
                    ProductTypeId = 4,
                    ProductBrandId = 4
                },
                new Product
                {
                    Name = "Product 14",
                    Description = "This is Product's 14 Description",
                    Price = 140m,
                    PictureUrl = "images/products/boot-redis1.png",
                    ProductTypeId = 3,
                    ProductBrandId = 6
                },
                new Product
                {
                    Name = "Product 15",
                    Description = "This is Product's 15 Description",
                    Price = 150m,
                    PictureUrl = "images/products/boot-core2.png",
                    ProductTypeId = 3,
                    ProductBrandId = 2
                },
                new Product
                {
                    Name = "Product 16",
                    Description = "This is Product's 16 Description",
                    Price = 160m,
                    PictureUrl = "images/products/boot-core1.png",
                    ProductTypeId = 3,
                    ProductBrandId = 2
                },
                new Product
                {
                    Name = "Product 17",
                    Description = "This is Product's 17 Description",
                    Price = 170m,
                    PictureUrl = "images/products/boot-ang2.png",
                    ProductTypeId = 3,
                    ProductBrandId = 1
                },
                new Product
                {
                    Name = "Product 18",
                    Description = "This is Product's 18 Description",
                    Price = 180m,
                    PictureUrl = "images/products/boot-ang1.png",
                    ProductTypeId = 3,
                    ProductBrandId = 1
                }
            };

            var brands = new List<ProductBrand>
            {
                new ProductBrand
                {
                    Id = 1,
                    Name = "Angular"
                },
                new ProductBrand
                {
                    Id = 2,
                    Name = "Angular"
                },
                new ProductBrand
                {
                    Id = 3,
                    Name = "Angular"
                },
                new ProductBrand
                {
                    Id = 4,
                    Name = "Angular"
                },
                new ProductBrand
                {
                    Id = 5,
                    Name = "Angular"
                },
                new ProductBrand
                {
                    Id = 6,
                    Name = "Angular"
                }
            };

            var types = new List<ProductType>
            {
                new ProductType
                {
                    Id = 1,
                    Name = "Boards"
                },
                new ProductType
                {
                    Id = 2,
                    Name = "Hats"
                },
                new ProductType
                {
                    Id = 3,
                    Name = "Boots"
                },
                new ProductType
                {
                    Id = 4,
                    Name = "Gloves"
                }
            };

            await context.Products.AddRangeAsync(products);
            await context.ProductBrands.AddRangeAsync(brands);
            await context.ProductTypes.AddRangeAsync(types);
            await context.SaveChangesAsync();
        }
    }
}
