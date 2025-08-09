using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demo.Domain.CustomerRelations.Enums;

namespace Demo.Infrastructure.Database.Models;

[Table("CustomerDocuments")]
internal class IdentityDocumentEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public CustomerEntity Customer { get; set; } = null!;

    [Required]
    public IdentityDocumentType Type { get; set; }

    [Required, MaxLength(50)]
    public string Number { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string IssuingAuthority { get; set; } = string.Empty;

    [Required]
    public DateOnly IssueDate { get; set; }

    [Required]
    public DateOnly ExpiryDate { get; set; }

    [Required]
    public IdentityDocumentVerificationStatus Status { get; set; }
}