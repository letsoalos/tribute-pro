using Core.Shared.Entities;

namespace Core.BurialPlans.Entities;

public class BurialPlan : BaseEntity
{
    public int BurialSchemeId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal BasePremium { get; set; }
    public int MaxMembers { get; set; }
    public bool IsActive { get; set; }

    public required BurialScheme BurialScheme { get; set; }
}
