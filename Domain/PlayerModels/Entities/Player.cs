using Domain.Abstractions;
using Domain.GameModels.Entities;
using Domain.ScoreModels.Entities;

namespace Domain.PlayerModels.Entities;

public sealed class Player : PlayerBase
{
    public Player(
        Guid id,
        string defaultPlayerName,
        string preferredPlayerName,
        bool isPlayerNameApproved,
        DateTimeOffset creationDate,
        string createdBy) :
        base(id, defaultPlayerName, preferredPlayerName, isPlayerNameApproved, creationDate, createdBy)
    {
    }

    public ICollection<Game> Games { get; set; }

    public ICollection<Score> Scores { get; set; }
}
