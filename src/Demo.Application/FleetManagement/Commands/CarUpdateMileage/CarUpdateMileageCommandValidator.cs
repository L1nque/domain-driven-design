using FluentValidation;

namespace Demo.Application.FleetManagement.Commands;

public class CarUpdateMileageCommandValidator : AbstractValidator<CarUpdateMileageCommand>
{
    public CarUpdateMileageCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Value)
            .NotEmpty()
            .GreaterThanOrEqualTo(0);
    }
}