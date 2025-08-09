using Demo.Application.Common.Exceptions;
using Demo.Application.RentalContracting.Interfaces;
using Demo.Domain.RentalContracting.Interfaces;
using Demo.Domain.RentalContracting.ValueObjects;
using MediatR;

namespace Demo.Application.RentalContracting.Commands;

public class RentalCloseCommandHandler : IRequestHandler<RentalCloseCommand>
{
    private readonly IRentalRepository _repository;
    private readonly IBillingAdapter _billingAdapter;

    public RentalCloseCommandHandler(IRentalRepository repository, IBillingAdapter billingAdapter)
    {
        _repository = repository;
        _billingAdapter = billingAdapter;
    }

    public async Task Handle(RentalCloseCommand request, CancellationToken cancellationToken = default)
    {
        var rental = await _repository.GetByIdAsync(RentalId.Create(request.Id), cancellationToken);
        NotFoundException.ThrowIfNull(rental);

        rental.Close(await _billingAdapter.GetClearance(rental.Id));

        await _repository.UpdateAsync(rental, cancellationToken);
    }
}