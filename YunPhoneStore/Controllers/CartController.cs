using Microsoft.AspNetCore.Mvc;

namespace QuanBichVanPS28709_ASM.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}
