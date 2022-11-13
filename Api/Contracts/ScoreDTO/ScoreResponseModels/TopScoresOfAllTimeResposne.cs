namespace Api.Contracts.ScoreDTO.ScoreResponseModels;

public class TopScoresOfAllTimeResposne
{
    List<ScoreAggregateRootResponse> Scores { get; init; }

    public TopScoresOfAllTimeResposne()
    {
        Scores = new List<ScoreAggregateRootResponse>();
    }
}
