using Demo.Application.Common.Exceptions;
using Demo.Application.RentalContracting.Interfaces;
using Demo.Domain.RentalContracting.Entities;
using Demo.Domain.RentalContracting.Enums;
using Demo.Domain.RentalContracting.ValueObjects;
using Demo.Infrastructure.Database;
using Demo.SharedKernel.Types;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Adapters;

internal class FleetAdapter : IFleetAdapter
{
    private readonly AppDbContext _dbContext;

    public FleetAdapter(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RentalCar> GetCarForRental(RentalCarId carId)
    {
        var car = await _dbContext.Cars.FirstOrDefaultAsync(x => x.Id == carId);
        NotFoundException.ThrowIfNull(car);

        var odometerUnits = car.OdometerUnits == Domain.FleetManagement.Enums.OdometerUnits.Km
            ? OdometerUnits.Km
            : OdometerUnits.Miles;

        return new RentalCar(
            id: RentalCarId.Create(car.Id),
            initialOdometerReading: new OdometerReading(odometerUnits, car.OdometerValue),
            initialFuelLevel: new FuelLevel((int)car.FuelLevel)
        );
    }
}