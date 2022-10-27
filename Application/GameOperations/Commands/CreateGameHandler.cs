using Application.Persistence;
using Domain.Entities;
using Domain.Errors;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Commands;

internal sealed class CreateGameHandler : IRequestHandler<CreateGameCommand, ErrorOr<Game>>
{
    private readonly IRepository<Game> _gameRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateGameHandler(IRepository<Game> gameRepository, IUnitOfWork unitOfWork)
    {
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Game>> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();
        var game = new Game(id, command.Name, true, command.CreatedBy);

        _gameRepository.Create(game);

        var hasErrorOccurred = await _unitOfWork.SaveAsync(cancellationToken);

        return hasErrorOccurred ? (ErrorOr<Game>)Errors.Game.CreateError : (ErrorOr<Game>)game;
    }
}