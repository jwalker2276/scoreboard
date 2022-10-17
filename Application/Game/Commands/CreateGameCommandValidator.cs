using FluentValidation;

namespace Application.Game.Commands
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
