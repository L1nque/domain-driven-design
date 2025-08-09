using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demo.Domain.CustomerRelations.Enums;

namespace Demo.Infrastructure.Database.Models;

[Table("CommunicationMethods")]
internal class CommunicationMethodEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid CustomerId { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public CustomerEntity Customer { get; set; } = null!;

    [Required]
    public CommunicationMethod Method { get; set; }
}