namespace Api.Contracts.PlayerDTO.PlayerResponseModels;

public class CheckPlayerNameResponse
{
    public bool IsNameAvailable { get; init; }

    public CheckPlayerNameResponse(bool isNameAvailable)
    {
        IsNameAvailable = isNameAvailable;
    }
}
