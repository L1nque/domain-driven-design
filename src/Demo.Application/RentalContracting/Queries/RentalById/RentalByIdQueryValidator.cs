using FluentValidation;

namespace Demo.Application.RentalContracting.Queries;

public class RentalByIdQueryValidator : AbstractValidator<RentalByIdQuery>
{
    public RentalByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();
    }
}