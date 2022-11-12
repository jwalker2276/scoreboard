namespace Api.Contracts.ScoreDTO.ScoreResponseModels;

public class CreateScoreResponse
{
    public string GameId { get; set; } = string.Empty;

    public int Score { get; set; }

    public string PlayerName { get; set; } = string.Empty;

    public bool IsRequestedNameApproved { get; set; }
}
