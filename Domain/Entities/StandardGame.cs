using Domain.Abstractions;

namespace Domain.Entities;

public sealed class StandardGame : Game
{
    public StandardGame(Guid id, string name, bool isActive, string createdBy) : base(id, name, isActive, createdBy)
    {
    }
}