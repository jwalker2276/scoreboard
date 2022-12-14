using Application.Persistence;
using Domain.Errors;
using Domain.GameModels.Entities;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Queries.GetbyId;

public sealed class GetGameByIdHandler : IRequestHandler<GetGameByIdQuery, ErrorOr<Game>>
{
    private readonly IRepository<Game> _gameRepository;

    public GetGameByIdHandler(IRepository<Game> gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<ErrorOr<Game>> Handle(GetGameByIdQuery query, CancellationToken cancellationToken)
    {
        Guid.TryParse(query.Id, out Guid gameId);

        Game? game = await _gameRepository.GetById(gameId, cancellationToken);

        return game is null ? Errors.Game.NotFound : game;
    }
}
