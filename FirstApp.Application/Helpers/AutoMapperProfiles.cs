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
            CreateMap<Product, ProductDto>();

            // FROM dto
        }
    }
}
