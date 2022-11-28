using Application.Persistence;
using Domain.PlayerModels.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence;

public class PlayerRepository : IPlayerRepository
{
    private readonly DatabaseContext _databaseContext;

    private readonly DbSet<Player> _dbPlayers;

    public PlayerRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _dbPlayers = _databaseContext.Set<Player>();
    }

    public void Create(Player entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<Player>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Player?> GetById(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Player?> GetByName(Expression<Func<Player, bool>> filter, CancellationToken cancellationToken)
    {
        List<Player> playersWithThatName = await _dbPlayers.Where(filter).ToListAsync(cancellationToken);

        return playersWithThatName.FirstOrDefault();
    }

    public Task<Player?> FindAndUpdate(Player updatedEntity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Player?> FindAndDelete(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
