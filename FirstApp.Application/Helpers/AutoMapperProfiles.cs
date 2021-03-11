using AutoMapper;
using FirstApp.Application.DTOs;
using FirstApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Application.Helpers
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
                .ForMember(dest => dest.PictureUrl, d => d.MapFrom(x=> string.Concat("~/", x.PictureUrl)));

            // FROM dto
            CreateMap<ProductCreateDto, Product>();
        }
    }
}
