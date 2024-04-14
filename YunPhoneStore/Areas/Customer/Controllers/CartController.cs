using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.Helper;
using QuanBichVanPS28709_ASM.Models.CartDto;
using QuanBichVanPS28709_ASM.Models.CategoryDto;
using QuanBichVanPS28709_ASM.Services;
using System.Text.Json;

namespace QuanBichVanPS28709_ASM.Areas.Customer.Controllers
{
    [Authorize] // bắt buộc đăng nhập mới xài đc
    [Area("Customer")]
    public class CartController : Controller
    {

        private readonly ICartService _cartService;
        private readonly ICategoryService _categoryService;
        public CartController(ICartService cartService, ICategoryService categoryService)
        {
            _cartService = cartService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string value = HttpContext.Session.GetString(Constant.CART_SESSION_KEY);
            CartDto cartInSession;
            if (value != null)
            {
                cartInSession = JsonSerializer.Deserialize<CartDto>(value)!;

            }
            else
            {
                cartInSession = new()
                {
                    cartItemDto = []
                };
            }
            ViewBag.Cart = cartInSession;
            IEnumerable<GetCategoryToView> categories = await _categoryService.GetAllCategories();
            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(CartItemDto cartItemDto)
        {
            string value = HttpContext.Session.GetString(Constant.CART_SESSION_KEY);

            if (value == null) //nếu session không tồn tại
            {
                //tạo session
                CartDto cart = new CartDto();
                cart.cartItemDto.Add(cartItemDto);

                HttpContext.Session.SetString(Constant.CART_SESSION_KEY, JsonSerializer.Serialize(cart));
            }
            else
            {
                CartDto cartInSession = JsonSerializer.Deserialize<CartDto>(value);
                CartItemDto cartItemDto1 = null;
                //kiểm tra sp tồn tại chưa, nếu có
                for (int i = 0; i < cartInSession!.cartItemDto.Count(); i++)
                {
                    if (cartInSession.cartItemDto[i].ProductId == cartItemDto.ProductId)
                    {
                        cartItemDto1 = cartInSession.cartItemDto[i];
                        cartInSession.cartItemDto[i].Quantity += 1;
                        break;
                    }
                }
                if (cartItemDto1 != null)
                {
                    //tìm product -> update quantity -> đưa vào session
                    HttpContext.Session.SetString(Constant.CART_SESSION_KEY, JsonSerializer.Serialize(cartInSession));
                }
                else //chưa
                {
                    //đưa cart vào list -> session
                    cartInSession.cartItemDto.Add(cartItemDto);
                    HttpContext.Session.SetString(Constant.CART_SESSION_KEY, JsonSerializer.Serialize(cartInSession));
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCartItem(Guid id)
        {
            string value = HttpContext.Session.GetString(Constant.CART_SESSION_KEY);
            if (value != null)
            {
                CartDto cartInSession = JsonSerializer.Deserialize<CartDto>(value)!;
                int index = -1;
                for (int i = 0; i < cartInSession!.cartItemDto.Count(); i++)
                {
                    if (cartInSession.cartItemDto[i].ProductId == id)
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1)
                {
                    cartInSession.cartItemDto.Remove(cartInSession.cartItemDto[index]);
                    HttpContext.Session.SetString(Constant.CART_SESSION_KEY, JsonSerializer.Serialize(cartInSession));
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateQuantity(UpdateQuantityDto updateQuantityDto)
        {
            string value = HttpContext.Session.GetString(Constant.CART_SESSION_KEY);
            if (value != null)
            {
                CartDto cartInSession = JsonSerializer.Deserialize<CartDto>(value)!;
                int index = -1;
                for (int i = 0; i < cartInSession!.cartItemDto.Count(); i++)
                {
                    if (cartInSession.cartItemDto[i].ProductId == updateQuantityDto.ProductId)
                    {
                        cartInSession.cartItemDto[i].Quantity = updateQuantityDto.Quantity;
                        break;
                    }
                }
                HttpContext.Session.SetString(Constant.CART_SESSION_KEY, JsonSerializer.Serialize(cartInSession));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut()
        {
            string value = HttpContext.Session.GetString(Constant.CART_SESSION_KEY);
            if (value != null)
            {
                CartDto cartInSession = JsonSerializer.Deserialize<CartDto>(value)!;
                HttpContext.Session.Remove(Constant.CART_SESSION_KEY);
                await _cartService.Checkout(cartInSession);
            }

            return RedirectToAction("Index");
        }
    }
}
