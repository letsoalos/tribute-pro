using Core.BurialPlans.Entities;
using Core.Shared.Entities;

namespace Core.Clients.Entities;

public class Client : BaseEntity
{
    public int TitleId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int IdentityTypeId { get; set; }
    public string? IdentityNumber { get; set; }
    public string? OtherIdentity { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int GenderId { get; set; }
    public int EthnicityId { get; set; }
    public int MaritalStatusId { get; set; }
    public required string CellPhone { get; set; }
    public string? AltNumber { get; set; }
    public string? Email { get; set; }
    public required string StreetName { get; set; }
    public required string Suburb { get; set; }
    public required string City { get; set; }
    public required string PostalCode { get; set; }
    public int BranchId { get; set; }
    public bool Consent { get; set; }
    public int? BurialPlanId { get; set; }
    public int? BurialSocietyId { get; set; }
    public DateTime DateJoined { get; set; } = DateTime.UtcNow;
    public int AddedByUserId { get; set; }
    public bool IsActive { get; set; } = true;
    public bool Deleted { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedByUserId { get; set; }


    public required Title Title { get; set; }
    public required Gender Gender { get; set; }
    public required MaritalStatus MaritalStatus { get; set; }
    public required IdentityType IdentityType { get; set; }
    public required Ethnicity Ethnicity { get; set; }
    public BurialPlan? BurialPlan { get; set; }
    public BurialSociety? BurialSociety { get; set; }
    public required Branch Branch { get; set; }


    // Computed Method
    public int GetAge()
    {
        var today = DateTime.Today;
        var age = today.Year - DateOfBirth.Year;
        if (DateOfBirth.Date > today.AddYears(-age)) age--;
        return age;
    }
}
