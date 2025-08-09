using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Demo.Domain.FleetManagement.Enums;

namespace Demo.Infrastructure.Database.Models;

[Table("CarServiceLogs")]
internal class ServiceLogEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public Guid CarId { get; set; }

    [ForeignKey(nameof(CarId))]
    public CarEntity Car { get; set; } = null!;

    [Required]
    public ServiceType Type { get; set; }

    [Required]
    public float ServicedAtMileage { get; set; }

    [Required]
    public float NextServiceThreshold { get; set; }
}