using Demo.Application.Common.Exceptions;
using Demo.Domain.FleetManagement;
using Demo.Domain.FleetManagement.ValueObjects;
using Demo.SharedKernel.Core.Abstractions;
using MediatR;

namespace Demo.Application.FleetManagement.Commands;

public class CarRegisterCommandHandler : IRequestHandler<CarRegisterCommand>
{
    private readonly IRepository<Car, CarId> _carsRepository;
    private readonly IRepository<Registration, RegistrationId> _registrationsRepository;

    public CarRegisterCommandHandler(IRepository<Car, CarId> carsRepository, IRepository<Registration, RegistrationId> registrationsRepository)
    {
        _carsRepository = carsRepository;
        _registrationsRepository = registrationsRepository;
    }

    public async Task Handle(CarRegisterCommand request, CancellationToken cancellationToken)
    {
        var registration = await _registrationsRepository.GetByIdAsync(new RegistrationId(request.RegistrationId));
        NotFoundException.ThrowIfNull(registration);

        var car = await _carsRepository.GetByIdAsync(new CarId(request.Id));
        NotFoundException.ThrowIfNull(car);

        car.RegisterCar(registration.Id);
        await _carsRepository.UpdateAsync(car);
    }
}