using Application.Common.Validation;
using FluentValidation;

namespace Application.GameOperations.Commands.Delete;

public sealed class DeleteGameCommandValidator : AbstractValidator<DeleteGameCommand>
{
    public DeleteGameCommandValidator()
    {
        RuleFor(c => c.Id)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(ValidationHelper.IsAGuid);
    }
}
