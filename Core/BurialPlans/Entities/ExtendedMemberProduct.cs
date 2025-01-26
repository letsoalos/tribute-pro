using Core.Shared.Entities;

namespace Core.BurialPlans.Entities;

public class ExtendedMemberProduct : BaseEntity
{
    public int BurialPlanId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Cost { get; set; }
    public string? EligibilityCriteria { get; set; } // Stored as JSON
    public bool IsActive { get; set; }

    public required BurialPlan BurialPlan { get; set; }
}
