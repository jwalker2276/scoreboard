namespace Api.Contracts.Game;

public class GameResponse
{
    public Guid Id { get; init; }

    public string Name { get; init; } = String.Empty;

    public bool IsActive { get; init; }

    public DateTimeOffset CreationDate { get; init; }

    public string CreatedBy { get; init; } = String.Empty;

    public GameResponse()
    {
    }

    public GameResponse(Domain.Entities.Game game)
    {
        Id = game.Id;
        Name = game.Name;
        IsActive = game.IsActive;
        CreationDate = game.CreationDate;
        CreatedBy = game.CreatedBy;
    }
}