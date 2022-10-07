using Domain.Common;

namespace Domain.Abstractions;

public abstract class Game : Entity
{
    protected Game(Guid id, string name, bool isActive, string createdBy) : base(id)
    {
        Name = name;
        IsActive = isActive;
        CreationDate = DateTimeOffset.Now;
        CreatedBy = createdBy;
    }

    public string Name { get; init; }

    public bool IsActive { get; init; }
        
    public DateTimeOffset CreationDate { get; init; }
    
    public string CreatedBy { get; init; }
}