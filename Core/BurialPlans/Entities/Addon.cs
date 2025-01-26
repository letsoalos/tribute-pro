using Core.Shared.Entities;

namespace Core.BurialPlans.Entities;

public class Addon : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Cost { get; set; }
    public bool IsActive { get; set; }
}
