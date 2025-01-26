using Core.Shared.Entities;

namespace Core.BurialPlans.Entities;

public class Benefit : BaseEntity
{
    public int BurialPlanId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int BenefitTypeId { get; set; } // Foreign key to BenefitType
    public decimal? Cost { get; set; }
    public bool IsActive { get; set; }

    public required BurialPlan BurialPlan { get; set; }
    public required BenefitType BenefitType { get; set; }
}
