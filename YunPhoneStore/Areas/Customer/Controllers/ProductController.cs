using Microsoft.AspNetCore.Mvc;
using QuanBichVanPS28709_ASM.Models.ProductDto;
using QuanBichVanPS28709_ASM.Models;
using QuanBichVanPS28709_ASM.Services;

namespace QuanBichVanPS28709_ASM.Areas.Customer.Controllers
{
    //[Route("[controller]")]
    [Area("Customer")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<HomeController> _logger;

        public ProductController(IProductService productService, ILogger<HomeController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [Route("{Id}")]
        public async Task<IActionResult> Detail(Guid Id)
        {
            GetProductsToView products = await _productService.GetProductById(Id);
            return View(products);
        }

        public async Task<IActionResult> Laptop()
        {
            FilterProduct filter = new FilterProduct();
            filter.CategoryId = new Guid("d0bf42cba77945b78e93429944023ee9");
            IEnumerable<GetProductsToView> products = await _productService.GetAllProductsByCategoryId(filter);
            return View(products);
        }

        public async Task<IActionResult> Phone() // đặt tên web trên Folder Product sao thì đây cũng phải same
        {
            FilterProduct filter = new FilterProduct();
            filter.CategoryId = new Guid("6ef6e3f6af5c4426acc783efe00051d4");
            IEnumerable<GetProductsToView> products = await _productService.GetAllProductsByCategoryId(filter);
            return View(products);
        }
    }
}
