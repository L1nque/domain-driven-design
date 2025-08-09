using Demo.Domain.RentalContracting.Entities;
using Demo.Domain.RentalContracting.ValueObjects;

namespace Demo.Application.RentalContracting.Interfaces;

public interface IDriverAdapter
{
    Task<Driver> GetDriver(DriverId id);
}