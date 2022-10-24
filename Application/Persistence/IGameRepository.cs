using Domain.Entities;

namespace Application.Persistence;

public interface IGameRepository
{
    public Task<Game> Add(Game game);

    public Task<Game?> GetGameById(Guid id);
}
