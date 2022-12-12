using Domain.Common;

namespace Domain.PlayerModels.ValueObjects;

public class PlayerName : ValueObject
{
    public string PreferredPlayerName { get; init; } = string.Empty;

    public PlayerName(string preferredPlayerName)
    {
        PreferredPlayerName = preferredPlayerName;
    }

    protected override IEnumerable<object> GetEqualityComponent()
    {
        yield return PreferredPlayerName;
    }
}
