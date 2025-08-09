using Demo.Domain.RentalContracting.Entities;
using Demo.Domain.RentalContracting.ValueObjects;

namespace Demo.Application.RentalContracting.Interfaces;

public interface IFleetAdapter
{
    Task<RentalCar> GetCarForRental(RentalCarId carId);
}