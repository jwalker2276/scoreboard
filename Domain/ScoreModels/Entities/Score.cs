using Domain.Abstractions;
using Domain.GameModels.Entities;
using Domain.PlayerModels.Entities;

namespace Domain.ScoreModels.Entities;

public sealed class Score : ScoreBase
{
    public Score(
        Guid id,
        int value,
        Guid gameId,
        Guid playerId,
        DateTimeOffset creationDate,
        string createdBy
        ) : base(id, value, gameId, playerId, creationDate, createdBy)
    {
    }

    public Game Game { get; set; }

    public Player Player { get; set; }
}
