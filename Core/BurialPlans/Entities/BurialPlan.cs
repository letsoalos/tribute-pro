using Core.Interfaces;
using Core.Shared.Entities;

namespace Core.BurialPlans.Entities;

public class BurialPlan : BaseEntity, ISoftDelete
{
    public int BurialSchemeId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal BasePremium { get; set; }
    public int MaxMembers { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }       // Soft delete flag
    public DateTime? DeletedAt { get; set; }

    public required BurialScheme BurialScheme { get; set; }
}
