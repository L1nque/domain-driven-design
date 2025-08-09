using Demo.Domain.RentalContracting.Enums;
using MediatR;

namespace Demo.Application.RentalContracting.Queries;

public record RentalsListQuery(
    int? Page = 1,
    int? PageSize = 10,
    RentalStatus? Status = null
) : IRequest<RentalsListQueryResponse>;
