using Domain.Common;

namespace Domain.Abstractions;

public abstract class GameBase : Entity<Guid>
{
    protected GameBase(
        Guid id,
        string name,
        bool isActive,
        string createdBy,
        DateTimeOffset creationDate) : base(id)
    {
        Name = name;
        IsActive = isActive;
        CreationDate = creationDate;
        CreatedBy = createdBy;
    }

    public string Name { get; private set; }

    public bool IsActive { get; private set; }

    public DateTimeOffset CreationDate { get; init; }

    public string CreatedBy { get; init; }

    public void UpdateName(string newName)
    {
        Name = newName;
    }

    public void UpdateIsActive(bool newState)
    {
        IsActive = newState;
    }
}