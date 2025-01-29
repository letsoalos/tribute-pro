using Core.Clients.Entities;
using Core.Interfaces;
using Core.Shared.Entities;

namespace Core.Members.Entities;

public class Member : BaseEntity, ISoftDelete
{
    public int ClientId { get; set; }
    public int TitleId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int GenderId { get; set; }
    public int RelationshipId { get; set; }
    public bool? IsBeneficiary { get; set; }
    public DateTime DateJoined { get; set; } = DateTime.UtcNow;
    public int AddedByUserId { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedByUserId { get; set; }

    public required Relationship Relationship { get; set; }
    public required Title Title { get; set; }
    public required Gender Gender { get; set; }
    public required Client Client { get; set; }


    // Computed Method
    public int GetAge()
    {
        var today = DateTime.Today;
        var age = today.Year - DateOfBirth.Year;
        if (DateOfBirth.Date > today.AddYears(-age)) age--;
        return age;
    }
}
