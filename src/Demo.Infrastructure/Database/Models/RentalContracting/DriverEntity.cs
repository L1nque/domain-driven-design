
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Infrastructure.Database.Models;

[Table("RentalDrivers")]
internal class DriverEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public DateTime LicenseIssueDate { get; set; }

    [Required]
    public DateTime LicenseExpiryDate { get; set; }

    public ICollection<RentalEntity> PrimaryDriverRentals { get; set; } = new List<RentalEntity>();
    public ICollection<RentalEntity> SecondaryDriverRentals { get; set; } = new List<RentalEntity>();
}