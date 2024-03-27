using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.Models;
using QuanBichVanPS28709_ASM.Models.ProductDto;
using QuanBichVanPS28709_ASM.Services;
using System.Diagnostics;

namespace QuanBichVanPS28709_ASM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<HomeController> _logger; // check log
        public HomeController(IProductService productService, ILogger<HomeController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        
        public async Task <IActionResult> Index()
        {
            Filter pagination = new Filter();
            IEnumerable<GetProductsToView> products = await _productService.GetAllProducts(pagination);
            return View(products);
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
