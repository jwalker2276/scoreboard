using Application.Persistence;
using Domain.Entities;
using Domain.Errors;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Commands.Update;

public sealed class UpdateGameHandler : IRequestHandler<UpdateGameCommand, ErrorOr<Game>>
{
    private readonly IRepository<Game> _gameRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateGameHandler(IRepository<Game> gameRepository, IUnitOfWork unitOfWork)
    {
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Game>> Handle(UpdateGameCommand command, CancellationToken cancellationToken)
    {
        Guid.TryParse(command.Id, out Guid gameId);

        Game? gameRecord = await _gameRepository.GetById(gameId, cancellationToken);

        if (gameRecord is null)
            return Errors.Game.NotFound;

        var updatedGame = new Game(gameId, command.Name, command.IsActive, gameRecord.CreatedBy, gameRecord.CreationDate);

        _gameRepository.Update(updatedGame);

        await _unitOfWork.SaveAsync(cancellationToken);

        return updatedGame;
    }
}
