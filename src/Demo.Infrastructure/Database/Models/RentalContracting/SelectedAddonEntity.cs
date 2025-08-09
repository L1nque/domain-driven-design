using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Infrastructure.Database.Models;

[Table("SelectedAddons")]
internal class SelectedAddonEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid RentalId { get; set; }

    [ForeignKey(nameof(RentalId))]
    public RentalEntity Rental { get; set; } = null!;

    [Required]
    public bool EnablesAdditionalDriver { get; set; }

    [Required]
    public int Quantity { get; set; }
}