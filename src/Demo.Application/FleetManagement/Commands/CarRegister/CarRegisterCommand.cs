using MediatR;

namespace Demo.Application.FleetManagement.Commands;

public record CarRegisterCommand(
    Guid Id,
    Guid RegistrationId
) : IRequest;