namespace Api.Contracts.GameRequests;

public class UpdateStandardGameRequest
{
    public Guid Id { get; init; } = Guid.Empty;

    public string Name { get; init; } = string.Empty;

    public bool IsActive { get; init; } = false;
}
