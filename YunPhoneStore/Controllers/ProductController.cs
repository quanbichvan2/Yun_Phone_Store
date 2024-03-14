using Microsoft.AspNetCore.Mvc;

namespace QuanBichVanPS28709_ASM.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Phone() // đặt tên web trên Folder Product sao thì đây cũng phải same
        {
            return View();
        }
        public IActionResult Laptop() // đặt tên web trên Folder Product sao thì đây cũng phải same
        {
            return View();
        }
    }
}
