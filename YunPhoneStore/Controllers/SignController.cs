using Microsoft.AspNetCore.Mvc;

namespace QuanBichVanPS28709_ASM.Controllers
{
    public class SignController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignIn() // đặt tên web trên Folder Product sao thì đây cũng phải same
        {
            return View();
        }
        public IActionResult SignUp() // đặt tên web trên Folder Product sao thì đây cũng phải same
        {
            return View();
        }
    }
}
