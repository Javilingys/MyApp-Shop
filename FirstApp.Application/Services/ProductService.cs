using AutoMapper;
using FirstApp.Application.DTOs;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        // временное пристанище, пока ищу реализацию юнит оф ворка.
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper,
            IGenericRepository<Product> productsRepo,
            IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this._productsRepo = productsRepo;
            this._productBrandRepo = productBrandRepo;
            this._productTypeRepo = productTypeRepo;
        }

        public async Task<IReadOnlyList<ProductDto>> GetProductsAsync()
        {
            var products = await _productsRepo.ListAllAsync();

            return _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);

            //var products = await _unitOfWork.Products.GetProductsAsync();
            //return _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            var productBrands = await _productBrandRepo.ListAllAsync();

            return productBrands;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            var productTypes = await _productTypeRepo.ListAllAsync();

            return productTypes;
        }
    }
}
