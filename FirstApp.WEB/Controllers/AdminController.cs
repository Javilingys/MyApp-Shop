using AutoMapper;
using FirstApp.Application.DTOs;
using FirstApp.Application.Interfaces;
using FirstApp.Domain.Entities;
using FirstApp.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstApp.WEB.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public AdminController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
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

            var productBrands = await _productService.GetProductBrandsAsync();
            var productTypes = await _productService.GetProductTypesAsync();

            ViewBag.Brands = new SelectList(await _productService.GetProductBrandsAsync(), "Id", "Name");
            ViewBag.Types = new SelectList(await _productService.GetProductTypesAsync(), "Id", "Name");



            return View(new ProductEditViewModel
            {
                ProductBrandId = productBrands.Where(b => b.Name == product.ProductBrand).Select(b => b.Id).FirstOrDefault(),
                ProductTypeId = productTypes.Where(t => t.Name == product.ProductType).Select(t => t.Id).FirstOrDefault(),
                ProductDto = product
            });
        }

        [HttpGet]
        public async Task<ActionResult<ProductBrandDto>> BrandTest()
        {
            return Ok(await _productService.GetProductBrandsAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductEditViewModel productViewModel)
        {
            if (ModelState.IsValid)
            {
                var createDto = _mapper.Map<ProductEditViewModel, ProductCreateDto>(productViewModel);
                await _productService.UpdateProduct(id, createDto);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
