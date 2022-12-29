using Domain.PlayerModels.Entities;

namespace Api.Contracts.PlayerDTO.PlayerResponseModels;

public class PlayerResponse
{
    public string PublicName { get; set; } = string.Empty;

    public PlayerResponse(Player player)
    {
        PublicName = GetDisplayNameValue(player);
    }

    private static string GetDisplayNameValue(Player playerData)
    {
        return !string.IsNullOrWhiteSpace(playerData.PreferredPlayerName) && playerData.IsPlayerNameApproved
            ? playerData.PreferredPlayerName
            : "Player";
    }
}
