using Demo.Domain.RentalContracting.Enums;
using Demo.SharedKernel.Types;
using MediatR;

namespace Demo.Application.RentalContracting.Commands;

public record RentalCreateCommand(
    Guid CarId,
    Guid DriverId,
    DateTimeOffset StartDate,
    DateTimeOffset EndDate,

    Money? DailyRate,
    Money? WeeklyRate,
    Money? MonthlyRate,

    OdometerUnits? OverrideUnits,
    float? OverrideMileage,
    Money? ExcessMileageCharge
) : IRequest<RentalCreateCommandResponse>;