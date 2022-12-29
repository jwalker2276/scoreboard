using Application.Common.Validation;
using Application.GameOperations.Queries.GetbyId;
using FluentValidation;

namespace Application.ScoreOperations.Queries.GetById;

public sealed class GetScoreByIdQueryValidator : AbstractValidator<GetGameByIdQuery>
{
    public GetScoreByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(ValidationHelper.IsAGuid);
    }
}
