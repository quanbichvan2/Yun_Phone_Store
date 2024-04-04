using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanBichVanPS28709_ASM.Areas.Admin.Models;
using QuanBichVanPS28709_ASM.Models.CategoryDto;
using QuanBichVanPS28709_ASM.Models.ProductDto;
using QuanBichVanPS28709_ASM.Services;
using System.Collections.Generic;

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
        public async Task<ActionResult> Index()
        {
            FilterProduct filter = new FilterProduct();
            IEnumerable<GetProductsToView> products = await _productService.GetAllProducts(filter);
            return View(products);
        }

        public async Task<ActionResult> ApplicationUser()
        {
            return View(User);
        }
        // GET: ProductController/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
        // GET: ProductController/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(Guid id)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
