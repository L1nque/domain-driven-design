using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demo.Domain.CustomerRelations.Enums;

namespace Demo.Infrastructure.Database.Models;

[Table("CustomerPhones")]
internal class CustomerPhoneEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public CustomerEntity Customer { get; set; } = null!;

    [Required, MaxLength(20)]
    public string Number { get; set; } = string.Empty;

    [MaxLength(3)]
    public string? CountryCode { get; set; }

    [Required]
    public PhoneType Type { get; set; }
    public bool IsPrimary { get; set; }
}