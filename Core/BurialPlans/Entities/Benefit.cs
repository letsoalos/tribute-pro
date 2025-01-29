using Core.Interfaces;
using Core.Shared.Entities;

namespace Core.BurialPlans.Entities;

public class Benefit : BaseEntity, ISoftDelete
{
    public int BurialPlanId { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public int BenefitTypeId { get; set; } // Foreign key to BenefitType
    public decimal? Cost { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }       // Soft delete flag
    public DateTime? DeletedAt { get; set; }

    public required BurialPlan BurialPlan { get; set; }
    public required BenefitType BenefitType { get; set; }
}
