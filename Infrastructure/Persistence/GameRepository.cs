using Application.Persistence;
using Domain.Entities;

namespace Infrastructure.Persistence
{
    internal class GameRepository : IGameRepository
    {
        private static List<Game> _games = new List<Game>();

        public Task<Game> Add(Game game)
        {
            _games.Add(game);

            return Task.FromResult(game);
        }

        public Task<Game?> GetGameById(Guid id)
        {
            return Task.FromResult(_games.SingleOrDefault(game => game.Id == id));
        }
    }
}
