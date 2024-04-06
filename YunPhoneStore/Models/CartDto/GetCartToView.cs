namespace QuanBichVanPS28709_ASM.Models.CartDto
{
    public class GetCartToView
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public decimal AmountItem 
        { 
            get
            {
                return Price * Quantity;
            }
        }

        public string Color { get; set; }
        public string Memory { get; set; }
        public decimal Total { get; set; }

    }
}
