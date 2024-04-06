using Microsoft.AspNetCore.Mvc;
using QuanBichVanPS28709_ASM.Models.ProductDto;
using QuanBichVanPS28709_ASM.Models;
using QuanBichVanPS28709_ASM.Services;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.Models.CategoryDto;
using QuanBichVanPS28709_ASM.Services.ServiceImp;

namespace QuanBichVanPS28709_ASM.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<HomeController> _logger;

        public ProductController(IProductService productService, ILogger<HomeController> logger, ICategoryService categoryService)
        {
            _productService = productService;
            _logger = logger;
            _categoryService = categoryService;
        }

        // Response view product detail
        [HttpGet("/product/category/{id}")]
        public async Task<IActionResult> Index(Guid id)
        {
            FilterProduct filter = new FilterProduct();
            filter.CategoryId = id;
            IEnumerable<GetProductsToView> products = await _productService.GetAllProductsByCategoryId(filter);
            IEnumerable<GetCategoryToView> categories = await _categoryService.GetAllCategories();
            ViewBag.Products = products;
            ViewBag.Categories = categories;
            return View();
        }

        // Response view product detail
        [HttpGet("product/{id}")]
        public async Task<IActionResult> Detail(Guid id)
        {
            GetProductsToView products = await _productService.GetProductById(id);
            IEnumerable<GetCategoryToView> categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = categories;
            return View(products);
        }
    }
}
