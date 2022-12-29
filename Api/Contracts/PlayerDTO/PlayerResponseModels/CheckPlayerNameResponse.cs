using Domain.PlayerModels.Entities;

namespace Api.Contracts.PlayerDTO.PlayerResponseModels;

public class CheckPlayerNameResponse
{
    public bool IsNameAvailable { get; init; }

    public bool IsNameApproved { get; init; }

    public CheckPlayerNameResponse(Player player)
    {
        IsNameAvailable = player.Id == Guid.Empty ? true : false;

        IsNameApproved = player.IsPlayerNameApproved;
    }
}
