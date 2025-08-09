using Demo.Application.Common.Exceptions;
using Demo.Domain.FleetManagement;
using Demo.Domain.FleetManagement.Entities;
using Demo.Domain.FleetManagement.ValueObjects;
using Demo.SharedKernel.Core.Abstractions;
using MediatR;

namespace Demo.Application.FleetManagement.Commands;

public class CarCompleteServiceCommandHandler : IRequestHandler<CarCompleteServiceCommand>
{
    private readonly IRepository<Car, CarId> _repository;

    public CarCompleteServiceCommandHandler(IRepository<Car, CarId> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CarCompleteServiceCommand request, CancellationToken cancellationToken)
    {
        var car = await _repository.GetByIdAsync(new CarId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(car);

        var serviceLog = new ServiceLog(request.NextServiceType, request.ServicedAt, request.NextServiceThreshold);
        car.CompleteService(serviceLog);

        await _repository.UpdateAsync(car);
    }
}