using Domain.ScoreModels.Entities;
using ErrorOr;
using MediatR;

namespace Application.ScoreOperations.Queries.GetById;

public class GetScoreByIdQuery : IRequest<ErrorOr<Score>>
{
    public string Id { get; init; }

    public GetScoreByIdQuery(string id)
    {
        Id = id;
    }
}
