using Api.Contracts.PlayerDTO.PlayerResponseModels;
using Domain.PlayerModels.Enitites;

namespace Api.Contracts.ScoreDTO.ScoreResponseModels;

public class ScoreAggregateRootResponse
{
    public string GameId { get; init; }

    public int Score { get; init; }

    public PlayerResponse Player { get; init; }

    public ScoreAggregateRootResponse(string gameId, Player player, int score)
    {
        GameId = gameId;
        Score = score;
        Player = new PlayerResponse(player);
    }
}
