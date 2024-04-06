using AutoMapper;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.DataAccess;
using QuanBichVanPS28709_ASM.Models.CartDto;

namespace QuanBichVanPS28709_ASM.Services.ServiceImp
{
    public class CartService : ICartService
    {
        private readonly ICartRepo _cartRepo;
        private readonly IMapper _mapper;
        public CartService(ICartRepo cartRepo, IMapper mapper)
        {
            _cartRepo = cartRepo;
            _mapper = mapper;
        }
        public async Task<Cart> Checkout(CartDto cartDto)
        {
            try
            {
                Cart cart = _mapper.Map<Cart>(cartDto);
                return await _cartRepo.Checkout(cart);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
