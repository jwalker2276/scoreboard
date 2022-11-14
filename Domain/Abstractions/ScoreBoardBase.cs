using Domain.Common;

namespace Domain.Abstractions;

public abstract class ScoreBoardBase : AggregateRoot<Guid>
{
    protected ScoreBoardBase(
        Guid id,
        Guid gameId,
        string name,
        int maxNumberOfScores,
        SortRule sortBy,
        DateTimeOffset creationDate,
        string createdBy) : base(id)
    {
        GameId = gameId;
        Name = name;
        MaxNumberOfScores = maxNumberOfScores;
        SortBy = sortBy;
        CreationDate = creationDate;
        CreatedBy = createdBy;
    }

    public Guid GameId { get; set; }

    public string Name { get; init; }

    public int MaxNumberOfScores { get; init; }

    public SortRule SortBy { get; init; }

    public DateTimeOffset CreationDate { get; init; }

    public string CreatedBy { get; init; }
}
