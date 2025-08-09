using FluentValidation;

namespace Demo.Application.RentalContracting.Commands;

public class RentalCreateCommandValidator : AbstractValidator<RentalCreateCommand>
{
    public RentalCreateCommandValidator()
    {
        RuleFor(x => x.CarId)
            .NotEmpty().WithMessage("Car ID is required.");

        RuleFor(x => x.DriverId)
            .NotEmpty().WithMessage("Driver ID is required.");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Start Date is required.")
            .LessThan(x => x.EndDate)
            .WithMessage("Start Date must be before End Date.");

        RuleFor(x => x.EndDate)
            .NotEmpty().WithMessage("End Date is required.")
            .GreaterThan(x => x.StartDate)
            .WithMessage("End Date must be after Start Date.");

        RuleFor(x => x.DailyRate)
            .Must(m => m == null || m.Amount >= 0)
            .WithMessage("Daily Rate cannot be negative.");

        RuleFor(x => x.WeeklyRate)
            .Must(m => m == null || m.Amount >= 0)
            .WithMessage("Weekly Rate cannot be negative.");

        RuleFor(x => x.MonthlyRate)
            .Must(m => m == null || m.Amount >= 0)
            .WithMessage("Monthly Rate cannot be negative.");

        RuleFor(x => x.OverrideMileage)
            .Must(v => v == null || v >= 0)
            .WithMessage("Mileage Override cannot be negative.");

        RuleFor(x => x.ExcessMileageCharge)
            .Must(m => m == null || m.Amount >= 0)
            .WithMessage("Excess Mileage Charge cannot be negative.");
    }
}