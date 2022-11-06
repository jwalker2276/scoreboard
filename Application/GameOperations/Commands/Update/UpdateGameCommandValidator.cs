using Application.Common.Validation;
using FluentValidation;

namespace Application.GameOperations.Commands.Update;

public sealed class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand>
{
    public UpdateGameCommandValidator()
    {
        RuleFor(q => q.Id)
           .Cascade(CascadeMode.Stop)
           .NotEmpty()
           .Must(ValidationHelper.IsAGuid);

        RuleFor(c => c.Name)
           .Cascade(CascadeMode.Stop)
           .NotEmpty()
           .MinimumLength(3)
           .MaximumLength(256)
           .Must(ValidationHelper.HaveAcceptableCharacters);

        RuleFor(c => c.IsActive)
           .Cascade(CascadeMode.Stop)
           .NotEmpty()
           .Must(IsActive => IsActive is true or false);
    }
}
