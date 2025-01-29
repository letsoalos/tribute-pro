using Core.Interfaces;
using Core.Shared.Entities;

namespace Core.BurialPlans.Entities;

public class ExtendedMemberProduct : BaseEntity, ISoftDelete
{
    public int BurialPlanId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Cost { get; set; }
    public string? EligibilityCriteria { get; set; } // Stored as JSON
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }       // Soft delete flag
    public DateTime? DeletedAt { get; set; }

    public required BurialPlan BurialPlan { get; set; }
}
