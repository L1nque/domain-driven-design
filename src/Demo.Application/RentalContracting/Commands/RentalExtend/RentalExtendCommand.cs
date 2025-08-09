using MediatR;

namespace Demo.Application.RentalContracting.Commands;

public record RentalExtendCommand(
    Guid Id,
    DateTimeOffset Date
) : IRequest;