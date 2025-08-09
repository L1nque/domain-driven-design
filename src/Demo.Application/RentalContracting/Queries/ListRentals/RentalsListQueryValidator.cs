using FluentValidation;

namespace Demo.Application.RentalContracting.Queries;

public class RentalsListQueryValidator : AbstractValidator<RentalsListQuery>
{
    public RentalsListQueryValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0);

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(0);
    }
}