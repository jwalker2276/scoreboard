using Domain.Abstractions;
using Domain.Common;

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
}
