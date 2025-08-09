using Demo.Domain.FleetManagement.Enums;
using MediatR;

namespace Demo.Application.FleetManagement.Commands;

public record CarCompleteServiceCommand(
    Guid Id,
    ServiceType NextServiceType,
    float NextServiceThreshold,
    float ServicedAt
) : IRequest;