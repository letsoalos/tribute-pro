namespace Core.Shared.Entities;

public class BurialSociety : BaseEntity
{
    public required string Name { get; set; }
    public required string ContactPerson { get; set; }
    public required string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public int Members { get; set; }
    public DateTime DateAdded { get; set; }
    public bool IsActive { get; set; }
}
