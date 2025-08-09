using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demo.Domain.CustomerRelations.Enums;

namespace Demo.Infrastructure.Database.Models;

[Table("Customers")]
internal class CustomerEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(200)]
    public string AddressStreet { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string AddressCity { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? AddressState { get; set; }

    [Required, MaxLength(20)]
    public string AddressPostalCode { get; set; } = string.Empty;

    [Required, MaxLength(3)]
    public string AddressCountryCode { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string AddressCountryName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string FirstName { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string LastName { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? MiddleNames { get; set; }

    [Required]
    public DateOnly DateOfBirth { get; set; }

    [Required, MaxLength(3)]
    public string NationalityCode { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string NationalityName { get; set; } = string.Empty;

    [Required, MaxLength(256)]
    public string Email { get; set; } = string.Empty;

    [MaxLength(20)]
    public string? PrimaryPhone { get; set; }

    [MaxLength(3)]
    public string? PrimaryPhoneCountryCode { get; set; }

    public PhoneType? PrimaryPhoneType { get; set; }

    public ICollection<CustomerPhoneEntity> PhoneNumbers { get; set; } = new List<CustomerPhoneEntity>();
    public ICollection<CommunicationMethodEntity> CommunicationMethods { get; set; } = new List<CommunicationMethodEntity>();

    public bool EmailOptIn { get; set; }
    public bool SmsOptIn { get; set; }
    public bool MarketingOptIn { get; set; }

    [MaxLength(10)]
    public string PreferredLanguage { get; set; } = "en";

    [MaxLength(50)]
    public string PreferredTimeZone { get; set; } = "UTC";

    [Required]
    public RiskLevel RiskLevel { get; set; }

    public int? TotalRentals { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? TotalSpentAmount { get; set; }

    [MaxLength(3)]
    public string? TotalSpentCurrency { get; set; }

    public float? AverageDrivingDistance { get; set; }

    public ICollection<IdentityDocumentEntity> Documents { get; set; } = new List<IdentityDocumentEntity>();
}
