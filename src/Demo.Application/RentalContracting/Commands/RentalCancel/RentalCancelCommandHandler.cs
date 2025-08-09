using Demo.Application.Common.Exceptions;
using Demo.Domain.RentalContracting.Interfaces;
using Demo.Domain.RentalContracting.ValueObjects;
using MediatR;

namespace Demo.Application.RentalContracting.Commands;

public class RentalCancelCommandHandler : IRequestHandler<RentalCancelCommand>
{
    private readonly IRentalRepository _repository;

    public RentalCancelCommandHandler(IRentalRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(RentalCancelCommand request, CancellationToken cancellationToken = default)
    {
        var rental = await _repository.GetByIdAsync(RentalId.Create(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(rental);

        rental.Cancel();
        await _repository.UpdateAsync(rental, cancellationToken);
    }
}