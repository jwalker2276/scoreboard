using Domain.Abstractions;
using Domain.Common;
using Domain.GameModels.Entities;
using Domain.ScoreModels.Entities;

namespace Domain.ScoreBoardModels.Entities;

public class ScoreBoard : ScoreBoardBase
{
    public ScoreBoard(
        Guid id,
        Guid gameId,
        string name,
        int maxNumberOfScores,
        SortRule sortBy,
        DateTimeOffset creationDate,
        string createdBy) : base(id, gameId, name, maxNumberOfScores, sortBy, creationDate, createdBy)
    {
    }

    public Game Game { get; set; }

    public ICollection<Score> Scores { get; set; }
}
