using Application.Persistence;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    internal class GameRepository : IGameRepository
    {
        private static List<StandardGame> _games = new List<StandardGame>();

        public Task<StandardGame> Add(StandardGame game)
        {
            _games.Add(game);

            return Task.FromResult(game);
        }

        public Task<StandardGame?> GetGameById(Guid id)
        {
            return Task.FromResult(_games.SingleOrDefault(game => game.Id == id));
        }
    }
}
