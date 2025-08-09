using FluentValidation;

namespace Demo.Application.RentalContracting.Commands;

public class RentalCheckInCommandValidator : AbstractValidator<RentalCheckInCommand>
{
    public RentalCheckInCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Rental ID is required.");
    }
}