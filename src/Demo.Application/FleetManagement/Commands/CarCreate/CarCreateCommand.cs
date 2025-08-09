using Demo.Domain.FleetManagement.Enums;
using MediatR;

namespace Demo.Application.FleetManagement.Commands;

public record CarCreateCommand(
    string Vin,
    string Brand,
    string Make,
    int Year,
    CarType CarType,
    OdometerUnits OdometerUnits,
    float OdometerReading,
    float NextServiceThreshold,
    FuelType FuelType,
    float FuelCapacity,
    float FuelLevel
) : IRequest<CarCreateCommandResponse>;