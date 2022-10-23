namespace Api.Contracts.Game;

public class CreateStandardGameRequest
{
    public string Name { get; init; } = String.Empty;

    public string CreatedBy { get; init; } = String.Empty;
}

