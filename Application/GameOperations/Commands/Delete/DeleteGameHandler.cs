using Application.Persistence;
using Domain.Entities.Game;
using Domain.Errors;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Commands.Delete;

public sealed class DeleteGameHandler : IRequestHandler<DeleteGameCommand, ErrorOr<Game>>
{
    private readonly IRepository<Game> _gameRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteGameHandler(IRepository<Game> gameRepository, IUnitOfWork unitOfWork)
    {
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Game>> Handle(DeleteGameCommand command, CancellationToken cancellationToken)
    {
        Guid.TryParse(command.Id, out Guid gameId);

        Game? gameToDelete = await _gameRepository.FindAndDelete(gameId, cancellationToken);

        if (gameToDelete is null)
            return Errors.Game.NotFound;

        await _unitOfWork.SaveAsync(cancellationToken);

        return gameToDelete;
    }
}
