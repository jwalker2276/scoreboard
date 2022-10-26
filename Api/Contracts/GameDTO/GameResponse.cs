using Domain.Entities;

namespace Api.Contracts.GameDTO;

public class GameResponse
{
    public Guid Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public bool IsActive { get; init; }

    public DateTimeOffset CreationDate { get; init; }

    public string CreatedBy { get; init; } = string.Empty;

    public GameResponse()
    {
    }

    public GameResponse(Game game)
    {
        Id = game.Id;
        Name = game.Name;
        IsActive = game.IsActive;
        CreationDate = game.CreationDate;
        CreatedBy = game.CreatedBy;
    }
}