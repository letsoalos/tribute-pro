using System.ComponentModel.DataAnnotations;

namespace Core.Policies.Entities;

public class PolicyType
{
    [Key]
    public required string PolicyTypeCode { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

}
