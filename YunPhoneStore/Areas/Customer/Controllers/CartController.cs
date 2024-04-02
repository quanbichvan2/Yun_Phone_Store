using Microsoft.AspNetCore.Mvc;
using QuanBichVanPS28709_ASM.Models.ProductDto;
using QuanBichVanPS28709_ASM.Models;

namespace QuanBichVanPS28709_ASM.Areas.Customer.Controllers
{
    public class CartController : Controller
    {
        [Area("Customer")]
        public IActionResult Cart()
        {
            //IEnumerable<GetProductsToView> products = await _productService.GetAllProductsByCategoryId(filter);
            //return View(products);
            return View();
        }
    }
}
