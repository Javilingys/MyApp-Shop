using AutoMapper;
using FirstApp.Application.DTOs;
using FirstApp.WEB.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.WEB.Helpers
{
    public class ProductUrlResolver: IValueResolver<ProductEditViewModel, ProductCreateDto, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(ProductEditViewModel source, ProductCreateDto destination, string destMember,
            ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.ProductDto.PictureUrl))
            {
                return source.ProductDto.PictureUrl;
            }

            return "images/products/placeholder.png";
        }
    }
}
