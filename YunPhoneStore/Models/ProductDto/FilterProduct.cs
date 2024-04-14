namespace QuanBichVanPS28709_ASM.Models.ProductDto
{
    public class FilterProduct
    {
        public FilterProduct()
        {
            page = 1;
            pageSize = 8;
        }
        public Guid? CategoryId { get; set; }
        public string? ProductName { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
    }
}
