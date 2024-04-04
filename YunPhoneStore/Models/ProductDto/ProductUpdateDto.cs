using AutoMapper;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.DataAccess;
using QuanBichVanPS28709_ASM.Models;

namespace QuanBichVanPS28709_ASM.Models.ProductDto
{
    public class ProductUpdateDto
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public string Name { get; set; }

        public string Memory { get; set; }

        public string Color { get; set; }

        public string Image { get; set; }

        public float Price { get; set; }

        public int Stock { get; set; }

        public string? Description { get; set; }

        public DateTimeOffset? UpdateDate { get; set; }

        public Guid? UpdateBy { get; set; }
        // thông tin đang được lấy lên và hiển thị :3
    }
}