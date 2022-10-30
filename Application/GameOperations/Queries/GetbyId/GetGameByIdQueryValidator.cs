using Application.Common.Validation;
using FluentValidation;

namespace Application.GameOperations.Queries.GetbyId;

internal class GetGameByIdQueryValidator : AbstractValidator<GetGameByIdQuery>
{
    public GetGameByIdQueryValidator()
    {
        RuleFor(q => q.Id)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
            .Must(ValidationHelper.IsAGuid);
    }
}
