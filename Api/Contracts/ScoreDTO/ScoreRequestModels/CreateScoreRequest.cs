namespace Api.Contracts.ScoreDTO.ScoreRequestModels;

public class CreateScoreRequest
{
    public string GameId { get; set; } = string.Empty;

    public string PlayerName { get; set; } = string.Empty;

    public int Score { get; set; } = 0;

    public string CreatedBy { get; set; } = string.Empty;
}
