namespace Core.Shared.Entities;

public class AppStatus : BaseEntity
{
    public required string StatusCode { get; set; }
    public required string Name { get; set; }
    public string? GroupTypeCode { get; set; }
}
