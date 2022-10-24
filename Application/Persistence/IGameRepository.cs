using Domain.Entities;

namespace Application.Persistence;

public interface IGameRepository
{
    public Task<Game> Add(Game game, CancellationToken token);

    public Task<Game?> GetGameById(Guid id, CancellationToken token);
}
