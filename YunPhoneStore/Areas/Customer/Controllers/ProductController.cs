using Microsoft.AspNetCore.Mvc;
using QuanBichVanPS28709_ASM.Models.ProductDto;
using QuanBichVanPS28709_ASM.Models;
using QuanBichVanPS28709_ASM.Services;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.Models.CategoryDto;
using QuanBichVanPS28709_ASM.Services.ServiceImp;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Text.Json;

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
        //Product/{categories}
        public async Task<IActionResult> Index()
        {
            IEnumerable<GetCategoryToView> categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = categories;
            ViewBag.Products = JsonSerializer.Deserialize<Filter<GetProductsToView>>(TempData["Products"]?.ToString());
            ViewBag.CategoryGuid = JsonSerializer.Deserialize<Guid>(TempData["CategoryGuid"]?.ToString());

            return View();
        }

        [HttpGet("/product/category/{id}")]
        public async Task<IActionResult> GetAllProductsByCategory(Guid id, [FromQuery] int currentPage)
        {
            FilterProduct filter = new()
            {
                CategoryId = id,
                pageSize = 4,
                page = currentPage
            };
            Filter<GetProductsToView> products = await _productService.GetAllProducts(filter);
            TempData["Products"] = JsonSerializer.Serialize(products);
            TempData["CategoryGuid"] = JsonSerializer.Serialize(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SearchProduct(FilterProduct filter)
        {
            Filter<GetProductsToView> products = await _productService.GetAllProducts(filter);
            TempData["Products"] = JsonSerializer.Serialize(products);
            TempData["CategoryGuid"] = JsonSerializer.Serialize(products.Data.First().Id);
            return RedirectToAction("Index");
        }
        /*  [HttpGet]
          public async Task<IActionResult> Pagination(Filter filter)
          {

          }*/
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
