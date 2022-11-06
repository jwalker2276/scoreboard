using Domain.Abstractions;

namespace Domain.Entities.Player.Enitites;

public sealed class Player : PlayerBase
{
    public Player(
        Guid id, string defaultPlayerName, string preferredPlayerName, bool isPlayerNameApproved,
        DateTimeOffset creationDate, string createdBy) :
        base(id, defaultPlayerName, preferredPlayerName, isPlayerNameApproved, creationDate, createdBy)
    {
    }
}
