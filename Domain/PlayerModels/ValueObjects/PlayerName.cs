using Domain.Common;

namespace Domain.PlayerModels.ValueObjects;

public class PlayerName : ValueObject
{
    public string DefaultPlayerName { get; init; } = string.Empty;

    public string PreferredPlayerName { get; init; } = string.Empty;

    public PlayerName(string defaultPlayerName, string preferredPlayerName)
    {
        DefaultPlayerName = defaultPlayerName;
        PreferredPlayerName = preferredPlayerName;
    }

    protected override IEnumerable<object> GetEqualityComponent()
    {
        yield return DefaultPlayerName;
        yield return PreferredPlayerName;
    }
}
