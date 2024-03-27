using Persistence.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class Discount : EntityAuditBase
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string DiscountPrice { get; set;}
        public DateTimeOffset StartDate { get; set; } // DateTimeOfSet nó dễ convert hơn dateTime
        public DateTimeOffset ExpireDate { get; set;}
        public bool IsValidDate { get; set; }
        public string? Description { get; set; }
        public virtual List<Product>? Products { get; set; }

    }
}
