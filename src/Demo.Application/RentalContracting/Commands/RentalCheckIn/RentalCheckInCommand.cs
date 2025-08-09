using MediatR;

namespace Demo.Application.RentalContracting.Commands;

public record RentalCheckInCommand(
    Guid Id
) : IRequest;