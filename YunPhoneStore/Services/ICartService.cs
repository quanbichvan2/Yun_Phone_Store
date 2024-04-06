using Persistence.Entities;
using QuanBichVanPS28709_ASM.Models.CartDto;

namespace QuanBichVanPS28709_ASM.Services
{
    public interface ICartService
    {
        // task là xử lý bất đồng bộ
        Task<Cart> Checkout(CartDto cartDto);
    }
}