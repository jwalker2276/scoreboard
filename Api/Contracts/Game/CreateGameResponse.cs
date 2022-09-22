namespace Api.Contracts.Game;

public record CreateGameResponse(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreationDate,
    string CreatedBy
    );