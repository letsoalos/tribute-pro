using Core.Shared.Entities;

namespace Core.Premiums.Entities;

public class PremiumPlan : BaseEntity
{
    public required string Name { get; set; } // E.g., "Member Only", "Single Parent", "Family"
    public decimal BasePremium { get; set; } // E.g., R95, R140, R200
    public required string PlanType { get; set; } // E.g., "MemberOnly", "Family", etc.
    public string? Description { get; set; }
    public bool IsActive { get; set; }

}
