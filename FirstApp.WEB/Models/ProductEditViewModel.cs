using FirstApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.WEB.Models
{
    public class ProductEditViewModel
    {
        public ProductDto ProductDto { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }


    }
}
