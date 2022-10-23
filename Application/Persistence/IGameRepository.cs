namespace Application.Persistence
{
    public interface IGameRepository
    {
        public Task<Domain.Entities.Game> Add(Domain.Entities.Game game);

        public Task<Domain.Entities.Game?> GetGameById(Guid id);
    }
}
