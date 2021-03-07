using FirstApp.Application.Interfaces;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FirstApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService service)
        {
            _logger = logger;
            _productService = service;
        }

        // GET: /Home
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/Shop
        public async Task<IActionResult> Shop()
        {
            return View(await _productService.GetProductsAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
