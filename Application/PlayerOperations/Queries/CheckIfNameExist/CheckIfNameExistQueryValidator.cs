using Application.Common.Validation;
using FluentValidation;

namespace Application.PlayerOperations.Queries.CheckIfNameExist;

public class CheckIfNameExistQueryValidator : AbstractValidator<CheckIfNameExistQuery>
{
    public CheckIfNameExistQueryValidator()
    {
        RuleFor(x => x.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(ValidationHelper.HaveAcceptableCharacters);
    }
}
