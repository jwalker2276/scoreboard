using Application.Persistence;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Commands;

public class CreateGameHandler : IRequestHandler<CreateGameCommand, ErrorOr<Game>>
{
    private readonly IGameRepository _gameRepository;

    public CreateGameHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<ErrorOr<Game>> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();
        var game = new Game(id, command.Name, true, command.CreatedBy);

        Game createdGame = await _gameRepository.Add(game, cancellationToken);

        return createdGame;
    }
}