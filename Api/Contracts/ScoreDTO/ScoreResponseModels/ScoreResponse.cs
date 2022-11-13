namespace Api.Contracts.ScoreDTO.ScoreResponseModels;

public class ScoreResponse
{
    public int Score { get; init; }

    public DateTimeOffset RecordDate { get; init; }

    // Update this take in score entity.
    public ScoreResponse()
    {

    }
}
