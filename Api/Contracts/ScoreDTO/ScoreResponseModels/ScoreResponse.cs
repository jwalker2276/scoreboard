namespace Api.Contracts.ScoreDTO.ScoreResponseModels;

public class ScoreResponse
{
    public string GameId { get; init; }

    public string Player { get; init; }

    public int Score { get; init; }

    // TODO: Update this to take entities
    public ScoreResponse(string gameId, string playerName, int score)
    {
        GameId = gameId;
        Player = playerName;
        Score = score;
    }
}
