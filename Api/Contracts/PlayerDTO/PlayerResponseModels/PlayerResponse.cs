namespace Api.Contracts.PlayerDTO.PlayerResponseModels;

public class PlayerResponse
{
    public string PlayerRequestName { get; set; } = string.Empty;

    public string PublicName { get; set; } = string.Empty;

    public bool IsRequestedNameApproved { get; set; }
}
