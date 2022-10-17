using Application.Persistence;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Game.Commands;

public class CreateGameHandler : IRequestHandler<CreateGameCommand, ErrorOr<StandardGame>>
{
    private readonly IGameRepository _gameRepository;

    public CreateGameHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<ErrorOr<StandardGame>> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();

        var game = new StandardGame(id, command.Name, true, command.CreatedBy);

        StandardGame createdGame = await _gameRepository.Add(game);

        return createdGame;
    }
}