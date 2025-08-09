using Demo.Application.Common.Exceptions;
using Demo.Domain.RentalContracting;
using Demo.Domain.RentalContracting.ValueObjects;
using Demo.SharedKernel.Core.Abstractions;
using MediatR;

namespace Demo.Application.RentalContracting.Commands;

public class RentalExtendCommandHandler : IRequestHandler<RentalExtendCommand>
{
    private readonly IRepository<Rental, RentalId> _repository;

    public RentalExtendCommandHandler(IRepository<Rental, RentalId> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RentalExtendCommand request, CancellationToken cancellationToken)
    {
        var rental = await _repository.GetByIdAsync(new RentalId(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(rental);

        rental.ExtendUntil(request.Date);
        await _repository.UpdateAsync(rental, cancellationToken);
    }
}