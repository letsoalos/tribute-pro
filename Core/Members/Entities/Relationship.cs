using Core.Shared.Entities;

namespace Core.Members.Entities;

public class Relationship : BaseEntity
{
    public required string Name { get; set; }
    public required string Description { get; set; }
}
