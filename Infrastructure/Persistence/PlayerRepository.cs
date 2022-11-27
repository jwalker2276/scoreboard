using Application.Persistence;
using Domain.PlayerModels.Entities;
using Infrastructure.CustomModels;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class PlayerRepository : IRepository<Player>
{
    private readonly DatabaseContext _databaseContext;

    private readonly DbSet<Player> _dbPlayers;

    private readonly DbSet<PlayerNameBlackList> _dbPlayerNameBlackLists;

    public PlayerRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _dbPlayers = _databaseContext.Set<Player>();
        _dbPlayerNameBlackLists = _databaseContext.Set<PlayerNameBlackList>();
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

    public Task<Player?> GetByName(string name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
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
