using Domain.ScoreBoardModels.Entities;
using ErrorOr;
using MediatR;

namespace Application.ScoreBoardOperations.Commands.Create;

public class CreateScoreBoardCommand : IRequest<ErrorOr<ScoreBoard>>
{
    public string GameId { get; init; }

    public string Name { get; init; }

    public int MaxNumberOfScores { get; init; }

    public string CreatedBy { get; init; }

    public CreateScoreBoardCommand(string gameId, string name, int maxNumberOfScores, string createdBy)
    {
        GameId = gameId;
        Name = name;
        MaxNumberOfScores = maxNumberOfScores;
        CreatedBy = createdBy;
    }
}
