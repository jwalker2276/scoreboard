using Application.Services.GameService.Common;

namespace Application.Services.GameService.Commands;

public class GameCommandService : IGameCommandService
{
    public GameResponse CreateGame()
    {
        return new GameResponse()
        {
            Id = Guid.NewGuid(),
            Name = String.Empty,
            IsActive = true,
            CreationDate = new DateTimeOffset(DateTime.Now, TimeSpan.Zero),
            CreatedBy = String.Empty
        };
    }
}