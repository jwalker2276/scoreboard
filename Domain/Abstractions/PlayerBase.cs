using Domain.Common;

namespace Domain.Abstractions;

public abstract class PlayerBase : Entity<Guid>
{
    protected PlayerBase(Guid id, string defaultPlayerName, string preferredPlayerName, bool isPlayerNameApproved, DateTimeOffset creationDate, string createdBy) : base(id)
    {
        DefaultPlayerName = defaultPlayerName;
        PreferredPlayerName = preferredPlayerName;
        IsPlayerNameApproved = isPlayerNameApproved;
        CreationDate = creationDate;
        CreatedBy = createdBy;
    }

    public string DefaultPlayerName { get; private set; }

    public string? PreferredPlayerName { get; private set; }

    public bool IsPlayerNameApproved { get; private set; }

    public DateTimeOffset CreationDate { get; init; }

    public string CreatedBy { get; init; }

    public void UpdateDefaultPlayerName(string newName)
    {
        DefaultPlayerName = newName;
    }

    public void UpdatePreferredPlayerName(string newName)
    {
        PreferredPlayerName = newName;
    }

    public void UpdateIsPlayerNameApproved(bool newState)
    {
        IsPlayerNameApproved = newState;
    }
}
