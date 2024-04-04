using Microsoft.AspNetCore.Mvc;
using QuanBichVanPS28709_ASM.Models.ProductDto;
using QuanBichVanPS28709_ASM.Models;
using Microsoft.AspNetCore.Authorization;

namespace QuanBichVanPS28709_ASM.Areas.Customer.Controllers
{
    public class CartController : Controller
    {
        [Authorize] // bắt buộc đăng nhập mới xài đc
        [Area("Customer")]
        public IActionResult Index()
        {
            //IEnumerable<GetProductsToView> products = await _productService.GetAllProductsByCategoryId(filter);
            //return View(products);
            return View();
        }
    }
}
