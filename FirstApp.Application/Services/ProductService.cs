using AutoMapper;
using FirstApp.Application.DTOs;
using FirstApp.Application.Interfaces;
using FirstApp.Domain.Entities;
using FirstApp.Domain.Interfaces;
using FirstApp.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FirstApp.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductDto>> GetProductsAsync()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await _unitOfWork.Repository<Product>().ListAsync(spec);

            return _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            //var products = await _unitOfWork.Products.GetProductsAsync();
            //return _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _unitOfWork.Repository<Product>().GetEntityWithSpec(spec);

            return _mapper.Map<Product, ProductDto>(product);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            var productBrands = await _unitOfWork.Repository<ProductBrand>().ListAllAsync();

            return productBrands;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            var productTypes = await _unitOfWork.Repository<ProductType>().ListAllAsync();

            return productTypes;
        }

        public async Task<Product> CreateProduct(ProductCreateDto productToCreate)
        {
            var product = _mapper.Map<ProductCreateDto, Product>(productToCreate);
            product.PictureUrl = "images/products/placeholder.png";

            _unitOfWork.Repository<Product>().Add(product);

            var result = await _unitOfWork.CompleteAsync();

            return product;
        }

        public async Task<Product> UpdateProduct(int id, ProductCreateDto productToUpdate)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);

            _mapper.Map(productToUpdate, product);

            _unitOfWork.Repository<Product>().Update(product);

            var result = await _unitOfWork.CompleteAsync();

            return product;
        }

        public async Task DeleteProduct(int id)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);

            _unitOfWork.Repository<Product>().Delete(product);

            var result = await _unitOfWork.CompleteAsync();
        }
    }
}
