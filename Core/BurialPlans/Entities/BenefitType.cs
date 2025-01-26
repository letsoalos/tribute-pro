using Core.Shared.Entities;

namespace Core.BurialPlans.Entities;

public class BenefitType : BaseEntity
{
    public required string Name { get; set; } // E.g., "Service", "Product"
    public string? Description { get; set; } // Optional detailed explanation
    public bool IsActive { get; set; }
}
