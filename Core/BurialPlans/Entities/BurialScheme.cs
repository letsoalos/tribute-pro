using Core.Interfaces;
using Core.Shared.Entities;

namespace Core.BurialPlans.Entities;

public class BurialScheme : BaseEntity, ISoftDelete
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public bool IsPayoutPlan { get; set; }
    public DateTime DateAdded { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }       // Soft delete flag
    public DateTime? DeletedAt { get; set; }
}
