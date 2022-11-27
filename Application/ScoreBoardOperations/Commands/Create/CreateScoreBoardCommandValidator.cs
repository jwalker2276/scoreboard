using Application.Common.Validation;
using FluentValidation;

namespace Application.ScoreBoardOperations.Commands.Create;

public class CreateScoreBoardCommandValidator : AbstractValidator<CreateScoreBoardCommand>
{
    public CreateScoreBoardCommandValidator()
    {
        RuleFor(sb => sb.GameId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(ValidationHelper.IsAGuid);

        RuleFor(sb => sb.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(256)
                .Must(ValidationHelper.HaveAcceptableCharacters);

        RuleFor(sb => sb.MaxNumberOfScores)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(100);

        RuleFor(sb => sb.CreatedBy)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(256)
                .Must(ValidationHelper.HaveAcceptableCharacters);
    }
}
