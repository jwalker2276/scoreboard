using Domain.PlayerModels.ValueObjects;
using Domain.ScoreModels.Entities;
using ErrorOr;
using MediatR;

namespace Application.ScoreOperations.Commands;

public class CreateScoreCommand : IRequest<ErrorOr<Score>>
{
    public int Value { get; init; }

    public PlayerName PlayerDetails { get; init; }

    public string ScoreBoardId { get; init; }

    public string CreatedBy { get; init; }

    public CreateScoreCommand(int value, PlayerName playerDetails, string scoreBoardId, string createdBy)
    {
        Value = value;
        PlayerDetails = playerDetails;
        ScoreBoardId = scoreBoardId;
        CreatedBy = createdBy;
    }
}
