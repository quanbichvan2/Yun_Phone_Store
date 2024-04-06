using AutoMapper;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.DataAccess;
using QuanBichVanPS28709_ASM.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanBichVanPS28709_ASM.Models.ProductDto
{
    public class ProductCreateDto
    {
        public Guid CategoryId { get; set; }
        public Guid? DiscountId { get; set; }
        public string Name { get; set; }
        public string Memory { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public string? Description { get; set; }
    }
}