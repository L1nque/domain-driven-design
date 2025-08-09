using Demo.Application.Common.Exceptions;
using Demo.Domain.RentalContracting.Interfaces;
using Demo.Domain.RentalContracting.ValueObjects;
using MediatR;

namespace Demo.Application.RentalContracting.Commands;

public class RentalCheckInCommandHandler : IRequestHandler<RentalCheckInCommand>
{
    private readonly IRentalRepository _repository;

    public RentalCheckInCommandHandler(IRentalRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(RentalCheckInCommand request, CancellationToken cancellationToken = default)
    {
        var rental = await _repository.GetByIdAsync(RentalId.Create(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(rental);

        rental.CheckIn();
        await _repository.UpdateAsync(rental, cancellationToken);
    }
}