using Api.Contracts.PlayerDTO.PlayerResponseModels;
using Domain.PlayerModels.Enitites;
using Domain.ScoreModels.Entities;

namespace Api.Contracts.ScoreDTO.ScoreResponseModels;

public class ScoreResponse
{
    public string GameId { get; init; }

    public ScoreObject Score { get; init; }

    public PlayerResponse Player { get; init; }

    public ScoreResponse(Guid gameId, Player player, Score score)
    {
        GameId = gameId.ToString();
        Score = new ScoreObject(score);
        Player = new PlayerResponse(player);
    }
}
