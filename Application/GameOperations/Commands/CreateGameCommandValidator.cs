using FluentValidation;

namespace Application.GameOperations.Commands
{
    public class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
    {
        public CreateGameCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.CreatedBy).NotEmpty();
        }
    }
}
