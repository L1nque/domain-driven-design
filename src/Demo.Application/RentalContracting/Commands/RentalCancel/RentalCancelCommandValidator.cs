using FluentValidation;

namespace Demo.Application.RentalContracting.Commands;

public class RentalCancelCommandValidator : AbstractValidator<RentalCancelCommand>
{
    public RentalCancelCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Rental ID is required.");
    }
}