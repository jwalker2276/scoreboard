using Application.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

internal class GameRepository : IRepository<Game>
{
    private readonly DatabaseContext _databaseContext;

    private readonly DbSet<Game> _dbSet;

    public GameRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _dbSet = _databaseContext.Set<Game>();
    }

    public void Create(Game game)
    {
        _dbSet.Add(game);
    }

    public async Task<List<Game>> GetAll(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<Game?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
    }

    public async Task<Game?> FindAndUpdate(Game updatedGame, CancellationToken cancellationToken)
    {
        Game? game = await _dbSet.FirstOrDefaultAsync(x => x.Id == updatedGame.Id, cancellationToken);

        if (game is null) return null;

        game.UpdateName(updatedGame.Name);
        game.UpdateIsActive(updatedGame.IsActive);

        return game;
    }

    public void Delete(Game game)
    {
        _dbSet.Remove(game);
    }
}
