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
    public class Category : EntityAuditBase
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        // Guid là 1 dạng dữ liệu chuỗi không phải string, nó random ra 1 key không bao giờ có sự trùng lặp
        [ForeignKey("BrandId")]
        public Guid BrandId { get; set; }
        public Brand? Brand { get; set; }
        [Required]
        public string CategoryName { get; set; }

    }
}
