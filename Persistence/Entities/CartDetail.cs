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
    public class CartDetail : EntityAuditBase
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        [ForeignKey("CartId")]
        public Guid CartId { get; set; }
        public Cart? Cart { get; set; }
        [ForeignKey("ProductId")]
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
        [Required]
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
