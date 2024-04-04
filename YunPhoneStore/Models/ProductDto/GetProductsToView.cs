using Persistence.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace QuanBichVanPS28709_ASM.Models.ProductDto
{
    public class GetProductsToView
    {
        public Guid Id { get; set; }

        public string CategoryName { get; set; }
        /*public Category? Category { get; set; }*/

        public string Name { get; set; }
        
        public string Memory { get; set; }

        public string Color { get; set; }
        
        public string Image { get; set; }
        
        public string CPU { get; set; }
        
        public float Price { get; set; }

        public string? Description { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public Guid? CreateBy { get; set; }

        public DateTimeOffset? UpdateDate { get; set; }

        public Guid? UpdateBy { get; set; }

    }
}
