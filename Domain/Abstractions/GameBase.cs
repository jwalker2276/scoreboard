using Domain.Common;

namespace Domain.Abstractions;

public abstract class GameBase : Entity
{
    protected GameBase(Guid id, string name, bool isActive, string createdBy, DateTimeOffset creationDate) : base(id)
    {
        Name = name;
        IsActive = isActive;
        CreationDate = creationDate;
        CreatedBy = createdBy;
    }

    public string Name { get; init; }

    public bool IsActive { get; init; }

    public DateTimeOffset CreationDate { get; init; }

    public string CreatedBy { get; init; }
}