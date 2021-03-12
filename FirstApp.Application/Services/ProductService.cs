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

        // Получение списка всех продуктов
        public async Task<IReadOnlyList<ProductDto>> GetProductsAsync()
        {
            // Продукты, включая тип и бренд
            var spec = new ProductsWithTypesAndBrandsSpecification();

            var products = await _unitOfWork.Repository<Product>().ListAsync(spec);

            return _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            //var products = await _unitOfWork.Products.GetProductsAsync();
            //return _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
        }

        // получить продукт по id
        public async Task<ProductDto> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await _unitOfWork.Repository<Product>().GetEntityWithSpec(spec);

            return _mapper.Map<Product, ProductDto>(product);
        }

        // получить список брендов
        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            var productBrands = await _unitOfWork.Repository<ProductBrand>().ListAllAsync();

            return productBrands;
        }

        // получить список типов продуктв
        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            var productTypes = await _unitOfWork.Repository<ProductType>().ListAllAsync();

            return productTypes;
        }

        // Создать продуктв
        public async Task<Product> CreateProduct(ProductCreateDto productToCreate)
        {
            var product = _mapper.Map<ProductCreateDto, Product>(productToCreate);
            product.PictureUrl = "images/products/placeholder.png";

            _unitOfWork.Repository<Product>().Add(product);

            var result = await _unitOfWork.CompleteAsync();

            return product;
        }

        // Отредактировать продуктв
        public async Task<Product> UpdateProduct(int id, ProductCreateDto productToUpdate)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);

            _mapper.Map(productToUpdate, product);

            _unitOfWork.Repository<Product>().Update(product);

            var result = await _unitOfWork.CompleteAsync();

            return product;
        }

        // Удалить продукт
        public async Task DeleteProduct(int id)
        {
            var product = await _unitOfWork.Repository<Product>().GetByIdAsync(id);

            _unitOfWork.Repository<Product>().Delete(product);

            var result = await _unitOfWork.CompleteAsync();
        }
    }
}
