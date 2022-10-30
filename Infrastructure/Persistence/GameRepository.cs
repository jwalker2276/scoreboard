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

    public async Task<IEnumerable<Game>> GetAll(CancellationToken cancellationToken)
    {
        return await _dbSet.ToListAsync(cancellationToken);
    }

    public async Task<Game?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public void Update(Game game)
    {
        _dbSet.Update(game);
    }

    public void Delete(Game game)
    {
        _dbSet.Remove(game);
    }
}
