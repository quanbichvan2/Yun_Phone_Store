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
    public class Account : EntityAuditBase // : EntityAuditBase
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid(); //  Guid.NewGuid(); tự random Id
        [ForeignKey("ProfileId")]
        public Guid ProfileId { get; set; }
        public Profile? Profile { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public DateTimeOffset LastLogin { get; set; } = DateTimeOffset.Now;
        [Required]
        public bool IsAnonymous { get; set; }
       
    }
}
