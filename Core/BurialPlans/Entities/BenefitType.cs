using Core.Interfaces;
using Core.Shared.Entities;

namespace Core.BurialPlans.Entities;

public class BenefitType : BaseEntity, ISoftDelete
{
    public required string Name { get; set; } // E.g., "Service", "Product"
    public string? Description { get; set; } // Optional detailed explanation
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }       // Soft delete flag
    public DateTime? DeletedAt { get; set; }
}
