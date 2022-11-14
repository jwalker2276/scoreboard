using Domain.Abstractions;

namespace Domain.ScoreModels.Entities;
public sealed class Score : ScoreBase
{
    public Score(
        Guid id,
        int value,
        DateTimeOffset creationDate,
        string createdBy,
        Guid gameId,
        Guid playerId) : base(id, value, creationDate, createdBy, gameId, playerId)
    {
    }
}
