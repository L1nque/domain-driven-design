using MediatR;

namespace Demo.Application.FleetManagement.Commands;

public record CarInsureCommand(
    Guid Id,
    Guid InsuranceId
) : IRequest;