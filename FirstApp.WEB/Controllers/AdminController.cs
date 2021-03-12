using FirstApp.Application.DTOs;
using FirstApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.WEB.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;

        public AdminController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetProductsAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _productService.GetProduct(id.Value);

            if (product == null)
            {
                return NotFound();
            }

            ViewBag.Brands = await _productService.GetProductBrandsAsync();
            ViewBag.Types = await _productService.GetProductTypesAsync();

            return View(product);
        }

        //TODO DELETE
        [HttpGet]
        public async Task<ActionResult<ProductBrandDto>> TestBrands()
        {

            return Ok(await _productService.GetProductBrandsAsync());
        }

        //TODO DELETE
        [HttpGet]
        public async Task<ActionResult<ProductBrandDto>> TestProducts()
        {

            return Ok(await _productService.GetProductsAsync());
        }

        //TODO DELETE
        [HttpGet]
        public async Task<ActionResult<ProductBrandDto>> TestTypes()
        {

            return Ok(await _productService.GetProductTypesAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductCreateDto productCreateDto)
        {
            return Ok();
        }
    }
}
