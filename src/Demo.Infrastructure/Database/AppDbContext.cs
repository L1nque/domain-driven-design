using Demo.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Database;

internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {

    }

    // Rental Contracting
    public DbSet<RentalEntity> Rentals { get; set; }
    public DbSet<DriverEntity> RentalDrivers { get; set; }
    public DbSet<RentalCarEntity> RentalCars { get; set; }
    public DbSet<SelectedAddonEntity> SelectedRentalAddons { get; set; }


    // Customer Relations
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<IdentityDocumentEntity> IdentityDocuments { get; set; }
    public DbSet<CommunicationMethodEntity> CommunicationMethods { get; set; }
    public DbSet<CustomerPhoneEntity> CustomerPhones { get; set; }

    // Fleet Management
    public DbSet<CarEntity> Cars { get; set; }
    public DbSet<ServiceLogEntity> ServiceLogs { get; set; }
    public DbSet<CarDamageEntity> CarDamages { get; set; }
}