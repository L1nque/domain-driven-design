using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demo.Domain.FleetManagement.Enums;

namespace Demo.Infrastructure.Database.Models;

[Table("CarDamages")]
internal class CarDamageEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid CarId { get; set; }

    [ForeignKey(nameof(CarId))]
    public CarEntity Car { get; set; } = null!;

    [Required]
    public DamageSeverity Severity { get; set; }

    [Required, MaxLength(1000)]
    public string Description { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal? CostOfRepairAmount { get; set; }

    [MaxLength(3)]
    public string? CostOfRepairCurrency { get; set; }

    [Required]
    public bool Insured { get; set; }
}