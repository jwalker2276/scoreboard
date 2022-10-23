using Application.Persistence;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Commands;

public class CreateGameHandler : IRequestHandler<CreateGameCommand, ErrorOr<Domain.Entities.Game>>
{
    private readonly IGameRepository _gameRepository;

    public CreateGameHandler(IGameRepository gameRepository)
    {
        _gameRepository = gameRepository;
    }

    public async Task<ErrorOr<Domain.Entities.Game>> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();

        var game = new Domain.Entities.Game(id, command.Name, true, command.CreatedBy);

        Domain.Entities.Game createdGame = await _gameRepository.Add(game);

        return createdGame;
    }
}