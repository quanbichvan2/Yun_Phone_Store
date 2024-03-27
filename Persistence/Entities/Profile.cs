using Persistence.Entities.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Entities
{
    public class Profile : EntityAuditBase
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Phone { get; set; }

        public string? Address { get; set; }
        public DateTimeOffset? BirthDate { get; set; } // để giảm giá thôi
        // 1 profiles có 1 account
        public Account? Account { get; set; } 
    }
}
