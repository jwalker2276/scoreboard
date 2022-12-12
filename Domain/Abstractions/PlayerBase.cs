using Domain.Common;

namespace Domain.Abstractions;

public abstract class PlayerBase : Entity<Guid>
{
    protected PlayerBase(
        Guid id,
        string preferredPlayerName,
        bool isPlayerNameApproved,
        DateTimeOffset creationDate,
        string createdBy) : base(id)
    {
        PreferredPlayerName = preferredPlayerName;
        IsPlayerNameApproved = isPlayerNameApproved;
        CreationDate = creationDate;
        CreatedBy = createdBy;
    }

    public string? PreferredPlayerName { get; private set; }

    public bool IsPlayerNameApproved { get; private set; }

    public DateTimeOffset CreationDate { get; init; }

    public string CreatedBy { get; init; }

    public void UpdatePreferredPlayerName(string newName)
    {
        PreferredPlayerName = newName;
    }

    public void UpdateIsPlayerNameApproved(bool newState)
    {
        IsPlayerNameApproved = newState;
    }
}
