using Demo.Application.Common.Exceptions;
using Demo.Domain.FleetManagement;
using Demo.Domain.FleetManagement.ValueObjects;
using Demo.SharedKernel.Core.Abstractions;
using MediatR;

namespace Demo.Application.FleetManagement.Commands;

public class CarUpdateMileageCommandHandler : IRequestHandler<CarUpdateMileageCommand>
{
    private readonly IRepository<Car, CarId> _repository;

    public CarUpdateMileageCommandHandler(IRepository<Car, CarId> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CarUpdateMileageCommand request, CancellationToken cancellationToken)
    {
        Car? car = await _repository.GetByIdAsync(CarId.Create(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(car);

        car.UpdateMileage(request.Value);

        await _repository.UpdateAsync(car);
    }
}