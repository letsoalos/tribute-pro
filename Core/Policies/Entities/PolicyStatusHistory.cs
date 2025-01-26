using Core.Shared.Entities;

namespace Core.Policies.Entities;

public class PolicyStatusHistory : BaseEntity
{
    public int PolicyId { get; set; }
    public required string Status { get; set; }
    public string? Reason { get; set; } // Reason for the status change
    public DateTime StatusChangedOn { get; set; } // When the status changed
    public int ChangedUserById { get; set; } // Link to the user/admin who made the change

    public required Policy Policy { get; set; }
    //public User ChangedUserById { get; set; }
}
