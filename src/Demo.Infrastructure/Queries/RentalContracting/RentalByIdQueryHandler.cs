using Demo.Application.Common.Exceptions;
using Demo.Application.RentalContracting.Queries;
using Demo.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Queries;

internal class RentalByIdQueryHandler : IRequestHandler<RentalByIdQuery, RentalByIdResponse>
{
    private readonly AppDbContext _dbContext;

    public RentalByIdQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RentalByIdResponse> Handle(RentalByIdQuery request, CancellationToken cancellationToken)
    {
        var rentalEntity = await _dbContext.Rentals.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        NotFoundException.ThrowIfNull(rentalEntity);

        return new RentalByIdResponse(
            Id: rentalEntity.Id,
            DurationInDays: (rentalEntity.EndDate - rentalEntity.StartDate).TotalDays
        );
    }
}