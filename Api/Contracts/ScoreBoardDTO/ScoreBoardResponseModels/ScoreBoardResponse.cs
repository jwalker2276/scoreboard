using Domain.ScoreBoardModels.Entities;

namespace Api.Contracts.ScoreBoardDTO.ScoreBoardResponseModels;

public class ScoreBoardResponse
{
    public string Id { get; set; }

    public string GameId { get; set; }

    public string Name { get; init; }

    public int MaxNumberOfScores { get; init; }

    public DateTimeOffset CreationDate { get; init; }

    public ScoreBoardResponse(ScoreBoard scoreBoard)
    {
        Id = scoreBoard.Id.ToString();
        GameId = scoreBoard.GameId.ToString();
        Name = scoreBoard.Name;
        MaxNumberOfScores = scoreBoard.MaxNumberOfScores;
        CreationDate = scoreBoard.CreationDate;
    }
}
