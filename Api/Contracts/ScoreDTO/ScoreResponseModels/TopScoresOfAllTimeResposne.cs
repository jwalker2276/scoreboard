namespace Api.Contracts.ScoreDTO.ScoreResponseModels;

public class TopScoresOfAllTimeResposne
{
    List<ScoreResponse> Scores { get; init; }

    public TopScoresOfAllTimeResposne()
    {
        Scores = new List<ScoreResponse>();
    }
}
