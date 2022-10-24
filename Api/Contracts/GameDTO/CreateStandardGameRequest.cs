namespace Api.Contracts.GameDTO;

public class CreateStandardGameRequest
{
    public string Name { get; init; } = string.Empty;

    public string CreatedBy { get; init; } = string.Empty;
}

