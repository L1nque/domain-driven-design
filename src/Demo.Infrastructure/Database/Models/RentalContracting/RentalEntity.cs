using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demo.Domain.RentalContracting.Enums;

namespace Demo.Infrastructure.Database.Models;

[Table("Rentals")]
internal class RentalEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid RentalCarId { get; set; }

    [ForeignKey(nameof(RentalCarId))]
    public RentalCarEntity Car { get; set; } = null!;

    [Required]
    public Guid PrimaryDriverId { get; set; }

    [ForeignKey(nameof(PrimaryDriverId))]
    public DriverEntity PrimaryDriver { get; set; } = null!;

    public Guid? SecondaryDriverId { get; set; }

    [ForeignKey(nameof(SecondaryDriverId))]
    public DriverEntity? SecondaryDriver { get; set; }

    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public RentalStatus Status { get; set; }

    [Required]
    public float MileageAllowanceValue { get; set; }

    [Required]
    public OdometerUnits MileageAllowanceUnits { get; set; }

    [Required, Column(TypeName = "decimal(18,2)")]
    public decimal MileageExcessChargeAmount { get; set; }

    [Required, MaxLength(3)]
    public string MileageExcessChargeCurrency { get; set; } = string.Empty;

    [Required, Column(TypeName = "decimal(18,2)")]
    public decimal DailyRateAmount { get; set; }

    [Required, MaxLength(3)]
    public string DailyRateCurrency { get; set; } = string.Empty;

    [Required, Column(TypeName = "decimal(18,2)")]
    public decimal WeeklyRateAmount { get; set; }

    [Required, MaxLength(3)]
    public string WeeklyRateCurrency { get; set; } = string.Empty;

    [Required, Column(TypeName = "decimal(18,2)")]
    public decimal MonthlyRateAmount { get; set; }

    [Required, MaxLength(3)]
    public string MonthlyRateCurrency { get; set; } = string.Empty;

    public ICollection<SelectedAddonEntity> SelectedAddons { get; set; } = new List<SelectedAddonEntity>();
}