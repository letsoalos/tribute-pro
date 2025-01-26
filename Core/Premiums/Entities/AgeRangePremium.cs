using Core.Shared.Entities;

namespace Core.Premiums.Entities;

public class AgeRangePremium : BaseEntity
{
    public int PremiumPlanId { get; set; } // Foreign key to PremiumPlan
    public int AgeFrom { get; set; } // E.g., 0
    public int AgeTo { get; set; } // E.g., 17
    public decimal MonthlyPremium { get; set; } // E.g., R15, R25

    public required PremiumPlan PremiumPlan { get; set; }
}
