using Application.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal class GameRepository : IGameRepository
{
    private readonly DatabaseContext _databaseContext;

    public GameRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public Task<Game> Add(Game game, CancellationToken cancellationToken)
    {
        _databaseContext.Add(game);

        return Task.FromResult(game);
    }

    public async Task<Game?> GetGameById(Guid id, CancellationToken cancellationToken)
    {
        return await _databaseContext.Set<Game>().FirstOrDefaultAsync(game => game.Id == id, cancellationToken);
    }
}
