using Domain.Common;

namespace Domain.Abstractions;

public abstract class ScoreBase : Entity<Guid>
{
    protected ScoreBase(
        Guid id,
        double value,
        DateTimeOffset creationDate,
        string createdBy,
        Guid gameId,
        Guid playerId) : base(id)
    {
        Value = value;
        CreationDate = creationDate;
        CreatedBy = createdBy;
        GameId = gameId;
        PlayerId = playerId;
    }

    public double Value { get; init; }

    public DateTimeOffset CreationDate { get; init; }

    public string CreatedBy { get; init; }

    public Guid GameId { get; init; }

    public Guid PlayerId { get; init; }
}
