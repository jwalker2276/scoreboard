namespace Api.Contracts.Game;

public class UpdateStandardGameRequest
{
    public Guid Id { get; init; } = Guid.Empty;

    public string Name { get; init; } = String.Empty;

    public bool IsActive { get; init; } = false;
}
