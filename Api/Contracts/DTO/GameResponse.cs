using Domain.Entities.Game;

namespace Api.Contracts.DTO;

public class GameResponse
{
    public string Id { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public bool IsActive { get; init; }

    public DateTimeOffset CreationDate { get; init; }

    public GameResponse()
    {
    }

    public GameResponse(Game game)
    {
        Id = game.Id.ToString();
        Name = game.Name;
        IsActive = game.IsActive;
        CreationDate = game.CreationDate;
    }
}