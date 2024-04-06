using Persistence.Entities.Bases;
using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities
{
    public class Cart : EntityAuditBase
    {
        [Key] public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public decimal Total { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
