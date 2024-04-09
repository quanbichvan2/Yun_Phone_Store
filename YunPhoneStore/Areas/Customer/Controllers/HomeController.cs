using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.Models;
using QuanBichVanPS28709_ASM.Models.CategoryDto;
using QuanBichVanPS28709_ASM.Models.ProductDto;
using QuanBichVanPS28709_ASM.Services;
using System.Diagnostics;
using Utility;

namespace QuanBichVanPS28709_ASM.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<HomeController> _logger; // check log
        public HomeController(IProductService productService, ILogger<HomeController> logger, ICategoryService categoryService)
        {
            _productService = productService;
            _logger = logger;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            FilterProduct pagination = new FilterProduct();
            IEnumerable<GetProductsToView> products = await _productService.GetAllProducts(pagination);
            IEnumerable<GetCategoryToView> categories = await _categoryService.GetAllCategories();
            ViewBag.Products = products;
            ViewBag.Categories = categories;
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
