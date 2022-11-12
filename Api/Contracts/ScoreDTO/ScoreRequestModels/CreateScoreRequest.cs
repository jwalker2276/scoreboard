namespace Api.Contracts.ScoreRequests;

public class CreateScoreRequest
{
    public string GameId { get; set; } = string.Empty;

    public string PlayerName { get; set; } = string.Empty;

    public int Score { get; set; } = 0;
}
