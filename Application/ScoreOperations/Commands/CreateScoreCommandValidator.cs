using Application.Common.Validation;
using Domain.PlayerModels.ValueObjects;
using FluentValidation;

namespace Application.ScoreOperations.Commands;

public class CreateScoreCommandValidator : AbstractValidator<CreateScoreCommand>
{
    public CreateScoreCommandValidator()
    {
        RuleFor(s => s.Value)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .LessThanOrEqualTo(2000000000)
            .WithMessage("Score value must be between 0 and 2 million.");

        RuleFor(sp => sp.PlayerDetails)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .Must(IsOneOfTheNamesValid)
            .WithMessage("Add least one of the player names must be valid");

        RuleFor(s => s.ScoreBoardId)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(ValidationHelper.IsAGuid);

        RuleFor(s => s.CreatedBy)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(ValidationHelper.HaveAcceptableCharacters);
    }

    private bool IsOneOfTheNamesValid(PlayerName playerDetails)
    {
        return ValidationHelper.IsOneOfTheStringsValid("Player", playerDetails.PreferredPlayerName);
    }
}
