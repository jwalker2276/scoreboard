using Domain.Abstractions;
using Domain.PlayerModels.Entities;
using Domain.ScoreBoardModels.Entities;

namespace Domain.ScoreModels.Entities;

public sealed class Score : ScoreBase
{
    public Score(
        Guid id,
        int value,
        Guid scoreBoardId,
        Guid playerId,
        DateTimeOffset creationDate,
        string createdBy
        ) : base(id, value, scoreBoardId, playerId, creationDate, createdBy)
    {
    }

    public ScoreBoard ScoreBoard { get; set; }

    public Player Player { get; set; }
}
