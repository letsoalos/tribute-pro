using Core.Shared.Entities;

namespace Core.BurialPlans.Entities;

public class BurialPlanAddon : BaseEntity
{
    public int BurialPlanId { get; set; }
    public int AddonId { get; set; }
    public bool IsMandatory { get; set; }

    public required BurialPlan BurialPlan { get; set; }
    public required Addon Addon { get; set; }
}
