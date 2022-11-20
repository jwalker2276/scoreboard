using Domain.Abstractions;
using Domain.PlayerModels.Entities;
using Domain.ScoreBoardModels.Entities;

namespace Domain.GameModels.Entities;

public sealed class Game : GameBase
{
    public Game(
        Guid id,
        string name,
        bool isActive,
        string createdBy,
        DateTimeOffset creationDate) :
        base(id, name, isActive, createdBy, creationDate)
    {
    }

    public ScoreBoard? ScoreBoard { get; set; }

    public ICollection<Player> Players { get; set; }
}