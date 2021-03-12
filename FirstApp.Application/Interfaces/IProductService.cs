using FirstApp.Application.DTOs;
using FirstApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Application.Interfaces
{
    public interface IProductService
    {
        Task<IReadOnlyList<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProduct(int id);
        Task<IReadOnlyList<ProductBrandDto>> GetProductBrandsAsync();
        Task<IReadOnlyList<ProductTypeDto>> GetProductTypesAsync();
        Task<Product> CreateProduct(ProductCreateDto productToCreate);
        Task<Product> UpdateProduct(int id, ProductCreateDto productToUpdate);
        Task DeleteProduct(int id);
    }
}
