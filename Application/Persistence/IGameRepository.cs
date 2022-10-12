using Domain.Entities;

namespace Application.Persistence
{
    public interface IGameRepository
    {
        public Task<StandardGame> Add(StandardGame game);

        public Task<StandardGame?> GetGameById(Guid id);
    }
}
