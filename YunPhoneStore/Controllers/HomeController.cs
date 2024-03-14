using Microsoft.AspNetCore.Mvc;
using QuanBichVanPS28709_ASM.Models;
using QuanBichVanPS28709_ASM.Services;
using System.Diagnostics;

namespace QuanBichVanPS28709_ASM.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //var columnNames = 
            //ViewBag.Products = columnNames;
            //return View(object);
            return View();
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
