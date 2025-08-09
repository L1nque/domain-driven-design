using FluentValidation;

namespace Demo.Application.RentalContracting.Commands;

public class RentalCloseCommandValidator : AbstractValidator<RentalCloseCommand>
{
    public RentalCloseCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Rental ID is required.");
    }
}