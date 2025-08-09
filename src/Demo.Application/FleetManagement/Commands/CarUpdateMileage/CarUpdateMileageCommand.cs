using MediatR;

namespace Demo.Application.FleetManagement.Commands;

public record CarUpdateMileageCommand(
    Guid Id,
    float Value
) : IRequest;