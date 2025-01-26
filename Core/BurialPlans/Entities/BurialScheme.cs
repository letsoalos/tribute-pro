using Core.Shared.Entities;

namespace Core.BurialPlans.Entities;

public class BurialScheme : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public bool IsPayoutPlan { get; set; }
    public DateTime DateAdded { get; set; }
    public bool IsActive { get; set; }
}
