using Domain.Abstractions;
using Domain.ScoreModels.Entities;

namespace Domain.PlayerModels.Entities;

public sealed class Player : PlayerBase
{
    public Player(
        Guid id,
        string preferredPlayerName,
        bool isPlayerNameApproved,
        DateTimeOffset creationDate,
        string createdBy) :
        base(id, preferredPlayerName, isPlayerNameApproved, creationDate, createdBy)
    {
    }

    public ICollection<Score> Scores { get; set; }
}
