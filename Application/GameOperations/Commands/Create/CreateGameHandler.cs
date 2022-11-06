using Application.Common.Dates;
using Application.Persistence;
using Domain.Entities.Game;
using Domain.Errors;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Commands.Create;

public sealed class CreateGameHandler : IRequestHandler<CreateGameCommand, ErrorOr<Game>>
{
    private readonly IRepository<Game> _gameRepository;

    private readonly IUnitOfWork _unitOfWork;

    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateGameHandler(IRepository<Game> gameRepository, IUnitOfWork unitOfWork, IDateTimeProvider dateTimeProvider)
    {
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<Game>> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid();
        DateTimeOffset creationDate = _dateTimeProvider.Now;
        var game = new Game(id, command.Name, true, command.CreatedBy, creationDate);

        _gameRepository.Create(game);

        var hasErrorOccurred = await _unitOfWork.SaveAsync(cancellationToken);

        return hasErrorOccurred ? (ErrorOr<Game>)Errors.Game.CreateError : (ErrorOr<Game>)game;
    }
}