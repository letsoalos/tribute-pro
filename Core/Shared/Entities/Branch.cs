namespace Core.Shared.Entities;

public class Branch : BaseEntity
{
    public required string Name { get; set; }
    public int AddressId { get; set; }
    public int ProvinceId { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Email { get; set; }
    public DateTime DateAdded { get; set; }
    public int? AddedByUserId { get; set; }
    public bool IsActive { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedByUserId { get; set; }


    public required Province Province { get; set; }
    public required Address Address { get; set; }
}
