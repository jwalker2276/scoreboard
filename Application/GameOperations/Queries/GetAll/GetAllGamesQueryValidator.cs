using FluentValidation;

namespace Application.GameOperations.Queries.GetAll;

public class GetAllGamesQueryValidator : AbstractValidator<GetAllGamesQuery>
{
    public GetAllGamesQueryValidator()
    {
    }
}
