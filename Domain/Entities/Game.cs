using Domain.Abstractions;

namespace Domain.Entities;

public sealed class Game : GameBase
{
    public Game(Guid id, string name, bool isActive, string createdBy, DateTimeOffset creationDate) :
        base(id, name, isActive, createdBy, creationDate)
    {
    }
}