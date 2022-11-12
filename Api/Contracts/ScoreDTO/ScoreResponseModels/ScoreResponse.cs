using Api.Contracts.PlayerDTO.PlayerResponseModels;

namespace Api.Contracts.ScoreDTO.ScoreResponseModels;

public class ScoreResponse
{
    public string GameId { get; init; }

    public int Score { get; init; }

    public PlayerNameResponse Player { get; init; }

    public ScoreResponse(string gameId, int score, PlayerNameResponse playerResponse)
    {
        GameId = gameId;
        Score = score;
        Player = playerResponse;
    }
}
