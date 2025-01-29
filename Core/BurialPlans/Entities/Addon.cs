using Core.Interfaces;
using Core.Shared.Entities;

namespace Core.BurialPlans.Entities;

public class Addon : BaseEntity, ISoftDelete
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Cost { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }       // Soft delete flag
    public DateTime? DeletedAt { get; set; }
}
