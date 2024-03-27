using Persistence.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class Brand : EntityAuditBase
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        
        [MaxLength(100)]
        public string BrandName { get; set; }
    }
}
