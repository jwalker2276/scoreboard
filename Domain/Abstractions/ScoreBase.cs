using Domain.Common;

namespace Domain.Abstractions;

public abstract class ScoreBase : Entity<Guid>
{
    protected ScoreBase(
        Guid id,
        int value,
        Guid gameId,
        Guid playerId,
        DateTimeOffset creationDate,
        string createdBy
        ) : base(id)
    {
        Value = value;
        CreationDate = creationDate;
        CreatedBy = createdBy;
        GameId = gameId;
        PlayerId = playerId;
    }

    public int Value { get; init; }

    public Guid GameId { get; init; }

    public Guid PlayerId { get; init; }

    public DateTimeOffset CreationDate { get; init; }

    public string CreatedBy { get; init; }
}
