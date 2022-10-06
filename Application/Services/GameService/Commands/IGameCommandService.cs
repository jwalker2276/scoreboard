using Application.Services.GameService.Common;

namespace Application.Services.GameService.Commands;

public interface IGameCommandService
{
    public GameResponse CreateGame();
}