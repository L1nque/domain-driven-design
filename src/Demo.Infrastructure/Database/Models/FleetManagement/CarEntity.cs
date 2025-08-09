using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demo.Domain.FleetManagement.Enums;

namespace Demo.Infrastructure.Database.Models;

[Table("Cars")]
internal class CarEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(100)]
    public string ModelBrand { get; set; } = string.Empty;

    [Required, MaxLength(100)]
    public string ModelMake { get; set; } = string.Empty;

    [Required]
    public int ModelYear { get; set; }

    [Required]
    public CarType ModelType { get; set; }

    [Required]
    public float OdometerValue { get; set; }

    [Required]
    public OdometerUnits OdometerUnits { get; set; }

    [Required]
    public float OdometerNextServiceThreshold { get; set; }

    [Required, MaxLength(17)]
    public string VinNumber { get; set; } = string.Empty;

    [Required]
    public float FuelLevel { get; set; }

    [Required]
    public float FuelCapacity { get; set; }

    [Required]
    public FuelType FuelType { get; set; }

    public Guid? InsurancePolicyId { get; set; }

    [MaxLength(50)]
    public string? InsurancePolicyNumber { get; set; }

    public DateTime? InsuranceExpirationDate { get; set; }

    public Guid? RegistrationId { get; set; }

    [Required]
    public CarStatus Status { get; set; }

    [Required]
    public bool RequiresCleaning { get; set; }

    public ICollection<CarDamageEntity> Damages { get; set; } = new List<CarDamageEntity>();
    public ICollection<ServiceLogEntity> ServiceHistory { get; set; } = new List<ServiceLogEntity>();
}