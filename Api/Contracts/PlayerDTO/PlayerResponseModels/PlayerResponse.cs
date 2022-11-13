using Domain.PlayerModels.Enitites;

namespace Api.Contracts.PlayerDTO.PlayerResponseModels;

public class PlayerResponse
{
    public string DisplayName { get; set; } = string.Empty;

    public PlayerResponse(Player player)
    {
        DisplayName = GetDisplayNameValue(player);
    }

    private static string GetDisplayNameValue(Player playerData)
    {
        return !string.IsNullOrWhiteSpace(playerData.PreferredPlayerName) && playerData.IsPlayerNameApproved
            ? playerData.PreferredPlayerName
            : playerData.DefaultPlayerName;
    }
}
