using Application.Persistence;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Queries.GetAll;
public sealed class GetAllGamesHandler : IRequestHandler<GetAllGamesQuery, ErrorOr<List<Game>>>
{
    private readonly IRepository<Game> _gameRepository;

    public GetAllGamesHandler(IRepository<Game> gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<ErrorOr<List<Game>>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
    {
        List<Game> games = await _gameRepository.GetAll(cancellationToken);

        return games;
    }
}
