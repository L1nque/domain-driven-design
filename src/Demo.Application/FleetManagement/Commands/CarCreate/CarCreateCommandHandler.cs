using Demo.Domain.FleetManagement;
using Demo.Domain.FleetManagement.ValueObjects;
using Demo.SharedKernel.Core.Abstractions;
using MediatR;

namespace Demo.Application.FleetManagement.Commands;

public class CarCreateCommandHandler : IRequestHandler<CarCreateCommand, CarCreateCommandResponse>
{
    private readonly IRepository<Car, CarId> _repository;

    public CarCreateCommandHandler(IRepository<Car, CarId> repository)
    {
        _repository = repository;
    }

    public async Task<CarCreateCommandResponse> Handle(CarCreateCommand request, CancellationToken cancellationToken)
    {
        var vin = new Vin(request.Vin);
        var model = new CarModel(request.Brand, request.Make, request.Year, request.CarType);
        var odometer = new OdometerReading(request.OdometerUnits, request.OdometerReading, request.NextServiceThreshold);
        var fuelTank = new FuelTank(request.FuelType, request.FuelCapacity, request.FuelLevel);

        var car = new Car(vin, model, odometer, fuelTank);

        await _repository.AddAsync(car, cancellationToken);

        return new CarCreateCommandResponse(car.Id);
    }
}