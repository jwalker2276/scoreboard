namespace Api.Contracts.GameDTO.GameRequestModels;

public class UpdateStandardGameRequest
{
    public string Id { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public bool IsActive { get; init; } = false;
}
