using Application.Common.Validation;
using FluentValidation;

namespace Application.GameOperations.Commands.Create;

public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
{
    public CreateGameCommandValidator()
    {
        RuleFor(c => c.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(256)
            .Must(ValidationHelper.HaveAcceptableCharacters);

        RuleFor(c => c.CreatedBy)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(256)
            .Must(ValidationHelper.HaveAcceptableCharacters);
    }
}
