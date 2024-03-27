using Persistence.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class Product : EntityAuditBase
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }

        public Category? Category { get; set; }

        [ForeignKey("DiscountId")]
        public Guid? DiscountId { get; set; } // !!! 1 mảng discount cho 1 product (cho trường hợp 1-n nhưng vẫn muốn n-n)
        public virtual Discount? Discount { get; set; } // virtual giúp ánh xạ EF (hỗ trợ lazy load)
        [Required]
        public string Name { get; set; }
        [Required]
        public string Memory { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Stock { get; set;}
        public string? Description { get; set; }

        // đoạn update, create đã đc thay trong entityAuditBase
    }
}
