using Domain.ScoreBoardModels.Entities;
using Domain.ScoreModels.Entities;

namespace Api.Contracts.ScoreBoardDTO.ScoreBoardResponseModels;

public class ScoreBoardResponse
{
    public string Id { get; set; }

    public string GameId { get; set; }

    public string Name { get; init; }

    public int MaxNumberOfScores { get; init; }

    public DateTimeOffset CreationDate { get; init; }

    public List<PlayerScoresObject> Scores { get; init; }

    public ScoreBoardResponse(ScoreBoard scoreBoard)
    {
        Id = scoreBoard.Id.ToString();
        GameId = scoreBoard.GameId.ToString();
        Name = scoreBoard.Name;
        MaxNumberOfScores = scoreBoard.MaxNumberOfScores;
        CreationDate = scoreBoard.CreationDate;
        Scores = BuildScordData(scoreBoard.Scores);
    }

    private List<PlayerScoresObject> BuildScordData(ICollection<Score> scores)
    {
        if (scores is null)
        {
            return new List<PlayerScoresObject>();
        }

        var data = new List<PlayerScoresObject>();

        foreach (Score score in scores)
        {
            data.Add(new PlayerScoresObject(score));
        }

        return data;
    }
}
