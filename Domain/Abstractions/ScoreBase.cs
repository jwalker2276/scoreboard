using Domain.Common;

namespace Domain.Abstractions;

public abstract class ScoreBase : Entity<Guid>
{
    protected ScoreBase(
        Guid id,
        int value,
        Guid scoreBoardId,
        Guid playerId,
        DateTimeOffset creationDate,
        string createdBy
        ) : base(id)
    {
        Value = value;
        CreationDate = creationDate;
        CreatedBy = createdBy;
        ScoreBoardId = scoreBoardId;
        PlayerId = playerId;
    }

    public int Value { get; init; }

    public Guid ScoreBoardId { get; init; }

    public Guid PlayerId { get; init; }

    public DateTimeOffset CreationDate { get; init; }

    public string CreatedBy { get; init; }
}
