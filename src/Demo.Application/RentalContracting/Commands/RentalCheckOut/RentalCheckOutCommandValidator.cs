using FluentValidation;

namespace Demo.Application.RentalContracting.Commands;

public class RentalCheckOutCommandValidator : AbstractValidator<RentalCheckOutCommand>
{
    public RentalCheckOutCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Rental ID is required.");

        RuleFor(x => x.FuelLevel)
            .NotEmpty()
            .LessThanOrEqualTo(10)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Fuel level must be a value between 1 and 10");

        RuleFor(x => x.OdometerValue)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .WithMessage("Odometer reading must not be negative.");
    }
}