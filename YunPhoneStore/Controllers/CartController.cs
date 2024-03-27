using Microsoft.AspNetCore.Mvc;
using QuanBichVanPS28709_ASM.Models.ProductDto;
using QuanBichVanPS28709_ASM.Models;

namespace QuanBichVanPS28709_ASM.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {
            //IEnumerable<GetProductsToView> products = await _productService.GetAllProductsByCategoryId(filter);
            //return View(products);
            return View();
        }
    }
}
