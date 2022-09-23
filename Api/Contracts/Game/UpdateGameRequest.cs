namespace Api.Contracts.Game;

public record UpdateGameRequest(
    Guid Id,
    string Name,
    bool IsActive
    );