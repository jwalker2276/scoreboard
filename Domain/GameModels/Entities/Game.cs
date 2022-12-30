using Domain.Abstractions;
using Domain.ScoreBoardModels.Entities;
using Domain.ScoreModels.Entities;

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

    public ICollection<Score>? Scores { get; set; }

    public ICollection<ScoreBoard>? ScoreBoards { get; set; }
}