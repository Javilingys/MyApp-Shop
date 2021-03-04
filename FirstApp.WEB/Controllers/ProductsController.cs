using FirstApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FirstApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            // TODO: Delete testData
            var testData = await _productService.GetProductsAsync();
            ViewData["testData"]= testData[0]?.Name;

            return View(await _productService.GetProductsAsync());
        }
    }
}
