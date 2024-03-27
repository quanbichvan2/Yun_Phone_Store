using Persistence.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class Cart : EntityAuditBase
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public float Total { get; set; }
    }
}
