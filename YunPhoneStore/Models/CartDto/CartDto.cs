using Persistence.Entities;

namespace QuanBichVanPS28709_ASM.Models.CartDto
{
    public class CartDto
    {
        public decimal Total { get { 
            return cartItemDto.Sum(p => p.Price * p.Quantity); } 
        }

        public string UserId { get; set; } = "yun";

        public List<CartItemDto> cartItemDto { get; set; } = new List<CartItemDto>();
    }

    public class CartItemDto
    {
        public Guid? CartId { get; set; }

        public Guid ProductId { get; set; }
        public string? Image { get; set; }
        public string? ProductName { get; set; }

        public int Quantity { get; set; } = 1;

        public decimal Price { get; set; }
    }
}
