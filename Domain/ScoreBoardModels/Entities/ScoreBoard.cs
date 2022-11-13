using Domain.Abstractions;
using Domain.Common;

namespace Domain.ScoreBoardModels.Entities;

public class ScoreBoard : ScoreBoardBase
{
    public ScoreBoard(
        Guid id,
        Guid gameId,
        string boardName,
        int maxNumberOfScores,
        SortRule sortBy,
        DateTimeOffset creationDate,
        string createdBy) : base(id, gameId, boardName, maxNumberOfScores, sortBy, creationDate, createdBy)
    {
    }
}
