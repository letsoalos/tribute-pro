using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace API.Dtos;

public class ClientDto
{
    // Core Identity Information
    public int Id { get; set; }

    [Required(ErrorMessage = "First name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be 2-50 characters")]
    public required string FirstName { get; set; }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be 2-50 characters")]
    public required string LastName { get; set; }

    [DateOfBirthValidation(MinYear = 1900, MinimumAge = 18)]
    public DateTime DateOfBirth { get; set; }

    public int Age => CalculateAge();

    // Demographic Information
    [Required(ErrorMessage = "Title is required")]
    [StringLength(10, ErrorMessage = "Title cannot exceed 10 characters")]
    public required string Title { get; set; }

    [Required(ErrorMessage = "Gender is required")]
    [RegularExpression(@"^(Male|Female|Other)$", ErrorMessage = "Invalid gender selection")]
    public required string Gender { get; set; }

    [Required(ErrorMessage = "Ethnicity is required")]
    public required string Ethnicity { get; set; }

    [Required(ErrorMessage = "Marital status is required")]
    [RegularExpression(@"^(Single|Married|Divorced|Widowed)$",
        ErrorMessage = "Invalid marital status")]
    public required string MaritalStatus { get; set; }

    // Identification Details
    [Required(ErrorMessage = "Identity type is required")]
    [RegularExpression(@"^(RSA ID|Passport|Asylum Seeker|Other)$",
        ErrorMessage = "Invalid identity type")]
    public required string IdentityType { get; set; }

    [StringLength(13, MinimumLength = 13, ErrorMessage = "ID number must be 13 digits")]
    [RegularExpression(@"^[0-9]{13}$", ErrorMessage = "Invalid ID number format")]
    [SouthAfricanIdValidation(ErrorMessage = "Invalid SA ID number")]
    public string? IdentityNumber { get; set; }

    [StringLength(20, ErrorMessage = "Other identity cannot exceed 20 characters")]
    public string? OtherIdentity { get; set; }

    // Contact Information
    private string _cellPhone = null!;

    [Required(ErrorMessage = "Cellphone number is required")]
    [RegularExpression(
        @"^(\+27|0|0027)\d{9}$",
        ErrorMessage = "Invalid SA number. Use +27821234567, 0821234567, or 0027821234567"
    )]
    [StringLength(13, MinimumLength = 10, ErrorMessage = "Number must be 10-13 digits")]
    public required string CellPhone
    {
        get => _cellPhone;
        set => _cellPhone = SanitizePhoneNumber(value);
    }

    [RegularExpression(@"^(\+27|0|0027)\d{9}$", ErrorMessage = "Invalid SA phone format")]
    public string? AltNumber { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email format")]
    [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
    public string? Email { get; set; }

    // Address Information
    [Required(ErrorMessage = "Street name is required")]
    [StringLength(100, ErrorMessage = "Street name cannot exceed 100 characters")]
    public required string StreetName { get; set; }

    [Required(ErrorMessage = "Suburb is required")]
    [StringLength(50, ErrorMessage = "Suburb cannot exceed 50 characters")]
    public required string Suburb { get; set; }

    [Required(ErrorMessage = "City is required")]
    [StringLength(50, ErrorMessage = "City cannot exceed 50 characters")]
    public required string City { get; set; }

    [Required(ErrorMessage = "Postal code is required")]
    [RegularExpression(@"^\d{4}$", ErrorMessage = "Invalid SA postal code (4 digits)")]
    public required string PostalCode { get; set; }

    // Institutional Relationships
    [Required(ErrorMessage = "Branch is required")]
    public required string Branch { get; set; }

    [Required(ErrorMessage = "Burial plan is required")]
    public required string BurialPlan { get; set; }

    [StringLength(50, ErrorMessage = "Burial society cannot exceed 50 characters")]
    public string? BurialSociety { get; set; }

    // Audit Fields
    public DateTime? ModifiedDate { get; set; }
    public int? ModifiedByUserId { get; set; }

    // Consent Management
    [Required(ErrorMessage = "Consent is required")]
    public bool Consent { get; set; }

    // Soft Delete Fields
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    private int CalculateAge()
    {
        var today = DateTime.UtcNow.Date;
        var age = today.Year - DateOfBirth.Year;
        if (DateOfBirth.Date > today.AddYears(-age)) age--;
        return age;
    }

    private static string SanitizePhoneNumber(string number)
    {
        var cleaned = number.Replace(" ", "").Replace("-", "");

        // Handle 0027 international format
        if (cleaned.StartsWith("0027") && cleaned.Length == 13)
        {
            return $"+27{cleaned[4..]}";
        }

        return cleaned.Length switch
        {
            10 when cleaned.StartsWith("0") => $"+27{cleaned[1..]}",
            11 when cleaned.StartsWith("27") => $"+{cleaned}",
            _ => cleaned
        };
    }
}

public class DateOfBirthValidationAttribute : ValidationAttribute
{
    public int MinYear { get; set; } = 1900;
    public bool AllowFutureDates { get; set; } = false;
    public int MinimumAge { get; set; } = 0;

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateTime date)
            return new ValidationResult("Valid date of birth is required");

        var today = DateTime.UtcNow.Date;
        var minDate = today.AddYears(-MinimumAge);

        if (!AllowFutureDates && date > today)
            return new ValidationResult("Birth date cannot be in the future");

        if (date.Year < MinYear)
            return new ValidationResult($"Birth year cannot be before {MinYear}");

        if (MinimumAge > 0 && date > minDate)
            return new ValidationResult($"Must be at least {MinimumAge} years old");

        return ValidationResult.Success;
    }
}

public class SouthAfricanIdValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string idNumber || string.IsNullOrWhiteSpace(idNumber))
            return ValidationResult.Success; // Let Required attribute handle null/empty

        if (idNumber.Length != 13 || !idNumber.All(char.IsDigit))
            return new ValidationResult("ID number must be 13 numeric digits");

        var datePart = idNumber[..6];
        var citizenship = idNumber[10];
        var checksum = idNumber[12];

        // Date validation
        if (!DateTime.TryParseExact(datePart, "yyMMdd",
            CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            return new ValidationResult("Invalid date component in ID number");
        }

        // Citizenship validation
        if (citizenship is not ('0' or '1'))
            return new ValidationResult("Invalid citizenship digit");

        // Luhn checksum validation
        if (!ValidateLuhnChecksum(idNumber))
            return new ValidationResult("Invalid ID number checksum");

        return ValidationResult.Success;
    }

    private static bool ValidateLuhnChecksum(string idNumber)
    {
        int sum = 0;
        bool alternate = false;

        for (int i = 0; i < 12; i++)
        {
            int digit = idNumber[i] - '0';

            if (alternate)
            {
                digit *= 2;
                if (digit > 9)
                    digit = (digit % 10) + 1;
            }

            sum += digit;
            alternate = !alternate;
        }

        int checkDigit = idNumber[12] - '0';
        int total = (sum % 10 == 0) ? 0 : 10 - (sum % 10);

        return total == checkDigit;
    }
}