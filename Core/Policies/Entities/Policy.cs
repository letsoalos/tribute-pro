using Core.Clients.Entities;
using Core.Premiums.Entities;
using Core.Shared.Entities;

namespace Core.Policies.Entities;

public class Policy : BaseEntity
{
    public required string PolicyTypeCode { get; set; }
    public required string PolicyNumber { get; set; }
    public int ClientId { get; set; }
    public int PremiumPlanId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; } // Null if policy is active
    public int CurrentStatusId { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }
    public int CreatedByUserId { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedByUserId { get; set; }

    public required Client Client { get; set; }
    public required PremiumPlan PremiumPlan { get; set; }
    public required AppStatus CurrentStatus { get; set; }
    public required PolicyType PolicyType { get; set; }

}
