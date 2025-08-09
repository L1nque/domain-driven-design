using MediatR;

namespace Demo.Application.RentalContracting.Commands;

public record RentalCloseCommand(
    Guid Id
) : IRequest;