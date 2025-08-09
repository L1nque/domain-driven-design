using Demo.Application.RentalContracting.Queries;
using Demo.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Demo.Infrastructure.Queries;

internal class RentalsListQueryHandler : IRequestHandler<RentalsListQuery, RentalsListQueryResponse>
{
    private readonly AppDbContext _dbContext;

    public RentalsListQueryHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<RentalsListQueryResponse> Handle(RentalsListQuery request, CancellationToken cancellationToken = default)
    {
        var query = _dbContext.Rentals.AsQueryable();
        var pageSize = request.PageSize ?? 10;
        var page = request.Page.HasValue ? (request.Page - 1 * pageSize) : 0;

        query = request.Status != null ? query.Where(x => x.Status == request.Status) : query;

        var rentals = await query
            .Skip(page.Value)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        return new RentalsListQueryResponse();
    }
}