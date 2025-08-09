using MediatR;

namespace Demo.Application.RentalContracting.Queries;

public record RentalByIdQuery(
    Guid Id
) : IRequest<RentalByIdResponse>;