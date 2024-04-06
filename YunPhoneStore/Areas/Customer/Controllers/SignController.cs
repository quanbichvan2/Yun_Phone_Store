using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.Models.CategoryDto;
using QuanBichVanPS28709_ASM.Services;

namespace QuanBichVanPS28709_ASM.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class SignController : Controller
    {
        private readonly ICategoryService _categoryService;
        public SignController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<GetCategoryToView> categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = categories;
            return View();
        }
        public async Task<IActionResult> SignIn() // đặt tên web trên Folder Product sao thì đây cũng phải same
        {
            IEnumerable<GetCategoryToView> categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = categories;
            return View();
        }
        public async Task<IActionResult> SignUp() // đặt tên web trên Folder Product sao thì đây cũng phải same
        {
            IEnumerable<GetCategoryToView> categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = categories;
            return View();
        }
    }
}
