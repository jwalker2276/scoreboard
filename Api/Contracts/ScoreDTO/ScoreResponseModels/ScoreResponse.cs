using Api.Contracts.PlayerDTO.PlayerResponseModels;
using Domain.ScoreModels.Entities;

namespace Api.Contracts.ScoreDTO.ScoreResponseModels;

public class ScoreResponse
{
    public string GameId { get; init; }

    public ScoreObject Score { get; init; }

    public PlayerResponse Player { get; init; }

    public ScoreResponse(Score score)
    {
        Score = new ScoreObject(score);
        GameId = score.GameId.ToString();
        Player = new PlayerResponse(score.Player);
    }
}
