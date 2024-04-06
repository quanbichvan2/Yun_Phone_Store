using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.Models.CategoryDto;
using QuanBichVanPS28709_ASM.Models.ProductDto;
using QuanBichVanPS28709_ASM.Services;
using QuanBichVanPS28709_ASM.Services.ServiceImp;

namespace QuanBichVanPS28709_ASM.Areas.Admin.Controllers
{
    [Authorize]
    [Area("admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger, ICategoryService categoryService)
        {
            _productService = productService;
            _logger = logger;
            _categoryService = categoryService;
        }
        // GET: ProductController
        public async Task<IActionResult> Index()
        {
            FilterProduct filter = new FilterProduct();
            IEnumerable<GetProductsToView> products = await _productService.GetAllProducts(filter);
            return View(products);
        }

        // GET: ProductController/Details/5

        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public async Task<IActionResult> Create()
        {
            IEnumerable<GetCategoryToView> categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = categories;
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateDto productDto)
        {
            Product product = await _productService.CreateProduct(productDto);
            if (product == null)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }

        // POST: ProductController/Edit/5
        [HttpPost("/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductUpdateDto productDto)
        {
            GetProductsToView product = await _productService.UpdateProduct(id, productDto);
            if (product == null)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }
        // GET: ProductController/Edit/5
        [HttpGet("/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            GetProductsToView product = await _productService.GetProductById(id);
            IEnumerable<GetCategoryToView> categories = await _categoryService.GetAllCategories();
            if (product == null)
            {
                return View("Error");
            }
            ViewBag.Product = product;
            ViewBag.Categories = categories;
            return View();
        }

        // GET: ProductController/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var check = await _productService.DeleteProduct(id);
            if (!check)
            {
                return View("Error");
            }
            return RedirectToAction("Index");
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
