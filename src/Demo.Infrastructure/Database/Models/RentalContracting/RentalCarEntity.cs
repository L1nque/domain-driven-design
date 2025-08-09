using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demo.Domain.RentalContracting.Enums;

namespace Demo.Infrastructure.Database.Models;

[Table("RentalCars")]
internal class RentalCarEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public float InitialOdometerValue { get; set; }

    [Required]
    public OdometerUnits InitialOdometerUnits { get; set; }

    public float? FinalOdometerValue { get; set; }

    public OdometerUnits? FinalOdometerUnits { get; set; }

    [Required]
    public float InitialFuelLevelValue { get; set; }

    public float? EndingFuelLevelValue { get; set; }

    [Required]
    public float DefaultMileageAllowanceValue { get; set; }

    [Required]
    public OdometerUnits DefaultMileageAllowanceUnits { get; set; }

    [Required, Column(TypeName = "decimal(18,2)")]
    public decimal DefaultMileageExcessChargeAmount { get; set; }

    [Required, MaxLength(3)]
    public string DefaultMileageExcessChargeCurrency { get; set; } = string.Empty;

    [Required, Column(TypeName = "decimal(18,2)")]
    public decimal DefaultDailyRateAmount { get; set; }

    [Required, MaxLength(3)]
    public string DefaultDailyRateCurrency { get; set; } = string.Empty;

    [Required, Column(TypeName = "decimal(18,2)")]
    public decimal DefaultWeeklyRateAmount { get; set; }

    [Required, MaxLength(3)]
    public string DefaultWeeklyRateCurrency { get; set; } = string.Empty;

    [Required, Column(TypeName = "decimal(18,2)")]
    public decimal DefaultMonthlyRateAmount { get; set; }

    [Required, MaxLength(3)]
    public string DefaultMonthlyRateCurrency { get; set; } = string.Empty;

    public ICollection<RentalEntity> Rentals { get; set; } = new List<RentalEntity>();
}