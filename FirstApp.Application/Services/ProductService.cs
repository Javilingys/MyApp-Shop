using FirstApp.Application.Interfaces;
using FirstApp.Domain.Entities;
using FirstApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}
