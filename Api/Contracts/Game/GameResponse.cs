namespace Api.Contracts.Game;

public record GameResponse(
    Guid Id,
    string Name,
    bool IsActive,
    DateTime CreationDate,
    string CreatedBy
    );