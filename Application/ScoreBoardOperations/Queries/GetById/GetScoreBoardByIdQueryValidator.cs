using Application.Common.Validation;
using FluentValidation;

namespace Application.ScoreBoardOperations.Queries.GetById;

public class GetScoreBoardByIdQueryValidator : AbstractValidator<GetScoreBoardByIdQuery>
{
    public GetScoreBoardByIdQueryValidator()
    {
        RuleFor(sb => sb.Id)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(ValidationHelper.IsAGuid);
    }
}
