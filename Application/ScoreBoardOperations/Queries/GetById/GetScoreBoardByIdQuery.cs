using Domain.ScoreBoardModels.Entities;
using ErrorOr;
using MediatR;

namespace Application.ScoreBoardOperations.Queries.GetById;

public class GetScoreBoardByIdQuery : IRequest<ErrorOr<ScoreBoard>>
{
    public string Id { get; set; }

    public GetScoreBoardByIdQuery(string id)
    {
        Id = id;
    }
}
