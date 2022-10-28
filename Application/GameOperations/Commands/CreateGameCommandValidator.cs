using FluentValidation;

namespace Application.GameOperations.Commands;

public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
{
    public CreateGameCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty()
            .MaximumLength(256)
            .Matches("[^a-zA-Z0-9 ]");

        RuleFor(c => c.CreatedBy)
            .NotEmpty()
            .MaximumLength(256)
            .Matches("[^a-zA-Z0-9 ]");
    }
}
