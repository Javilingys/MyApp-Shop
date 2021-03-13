using AutoMapper;
using FirstApp.Application.DTOs;
using FirstApp.Domain.Entities;
using FirstApp.WEB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.WEB.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // TO dto
            CreateMap<Product, ProductDto>()
                 .ForMember(destination => destination.ProductBrand,
                    options => options.MapFrom(prod => prod.ProductBrand.Name))
                .ForMember(dest => dest.ProductType,
                    opt => opt.MapFrom(prod => prod.ProductType.Name))
                .ForMember(dest => dest.PictureUrl, d => d.MapFrom(x => string.Concat("~/", x.PictureUrl)));
            CreateMap<ProductBrand, ProductBrandDto>();
            CreateMap<ProductType, ProductTypeDto>();

            // FROM dto
            CreateMap<ProductCreateDto, Product>();

            CreateMap<ProductEditViewModel, ProductCreateDto>()
                .ForMember(d => d.Name, opt => opt.MapFrom(pvm => pvm.ProductDto.Name))
                .ForMember(d => d.Description, opt => opt.MapFrom(pvm => pvm.ProductDto.Description))
                .ForMember(d => d.Price, opt => opt.MapFrom(pvm => pvm.ProductDto.Price))
                .ForMember(d => d.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>())
                .ForMember(d => d.ProductBrandId, opt => opt.MapFrom(pvm => pvm.ProductBrandId))
                .ForMember(d => d.ProductTypeId, opt => opt.MapFrom(pvm => pvm.ProductTypeId));
        }
    }
}
