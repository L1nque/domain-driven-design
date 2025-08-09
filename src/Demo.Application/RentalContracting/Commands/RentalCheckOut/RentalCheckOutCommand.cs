using MediatR;

namespace Demo.Application.RentalContracting.Commands;

public record RentalCheckOutCommand(
    Guid Id,
    float OdometerValue,
    int FuelLevel
) : IRequest;