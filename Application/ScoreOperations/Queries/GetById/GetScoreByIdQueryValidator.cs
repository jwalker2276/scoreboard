using Application.Common.Validation;
using FluentValidation;

namespace Application.ScoreOperations.Queries.GetById;

public sealed class GetScoreByIdQueryValidator : AbstractValidator<GetScoreByIdQuery>
{
    public GetScoreByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(ValidationHelper.IsAGuid);
    }
}
