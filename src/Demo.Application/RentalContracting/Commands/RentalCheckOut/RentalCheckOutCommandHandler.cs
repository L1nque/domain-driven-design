using Demo.Application.Common.Exceptions;
using Demo.Domain.RentalContracting.Interfaces;
using Demo.Domain.RentalContracting.ValueObjects;
using MediatR;

namespace Demo.Application.RentalContracting.Commands;

public class RentalCheckOutCommandHandler : IRequestHandler<RentalCheckOutCommand>
{
    private readonly IRentalRepository _repository;

    public RentalCheckOutCommandHandler(IRentalRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(RentalCheckOutCommand request, CancellationToken cancellationToken = default)
    {
        var rental = await _repository.GetByIdAsync(RentalId.Create(request.Id));
        NotFoundException.ThrowIfNull(rental);

        rental.CheckOut(
            new OdometerReading(rental.Car.InitialOdometer.Units, request.OdometerValue),
            new FuelLevel(request.FuelLevel)
        );

        await _repository.UpdateAsync(rental, cancellationToken);
    }
}