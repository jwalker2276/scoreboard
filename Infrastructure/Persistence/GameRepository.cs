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

    public IEnumerable<Game> GetAll()
    {
        return _dbSet.ToList();
    }

    public Game? GetById(Guid id)
    {
        return _dbSet.Find(id);
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
