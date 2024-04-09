namespace QuanBichVanPS28709_ASM.Models
{
    public class Filter<T>
    {
        public List<T> Data { get; set; }
        public PageInfo pageInfo { get; set; }
    }

    public class PageInfo
    {
        public int TotalItem {  get; set; }
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10; // 1 trang có 10 sản phẩm

    }
}
