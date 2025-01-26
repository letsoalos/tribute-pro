namespace Core.Shared.Entities;

public class Address : BaseEntity
{
    public required string StreetName { get; set; }
    public required string Suburb { get; set; }
    public required string City { get; set; }
    public required string Code { get; set; }
}
