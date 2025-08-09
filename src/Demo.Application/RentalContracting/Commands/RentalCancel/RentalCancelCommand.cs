using MediatR;

namespace Demo.Application.RentalContracting.Commands;

public record RentalCancelCommand(
    Guid Id
) : IRequest;