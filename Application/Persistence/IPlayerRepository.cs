using Domain.PlayerModels.Entities;

namespace Application.Persistence;

public interface IPlayerRepository : IRepository<Player>, IRepositoryNameSearch<Player>
{
}
