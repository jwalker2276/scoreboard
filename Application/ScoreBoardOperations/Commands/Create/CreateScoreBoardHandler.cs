using Application.Common.Dates;
using Application.Persistence;
using Domain.Common;
using Domain.Errors;
using Domain.GameModels.Entities;
using Domain.ScoreBoardModels.Entities;
using ErrorOr;
using MediatR;

namespace Application.ScoreBoardOperations.Commands.Create;

public class CreateScoreBoardHandler : IRequestHandler<CreateScoreBoardCommand, ErrorOr<ScoreBoard>>
{
    private readonly IRepository<ScoreBoard> _scoreBoardRepository;

    private readonly IRepository<Game> _gameRepository;

    private readonly IUnitOfWork _unitOfWork;

    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateScoreBoardHandler(
        IRepository<ScoreBoard> scoreBoardRepository,
        IRepository<Game> gameRepository,
        IUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider)
    {
        _scoreBoardRepository = scoreBoardRepository;
        _gameRepository = gameRepository;
        _unitOfWork = unitOfWork;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<ScoreBoard>> Handle(CreateScoreBoardCommand command, CancellationToken cancellationToken)
    {
        Game? foundGame = await CheckIfGameExist(command, cancellationToken);

        if (foundGame is null)
        {
            return (ErrorOr<ScoreBoard>)Errors.ScoreBoard.GameIdNotFound;
        }

        ScoreBoard scoreBoard = CreateScoreBoardFromCommandData(command, foundGame.Id);

        await AddScoreBoardIdToGame(scoreBoard, foundGame, cancellationToken);

        await _unitOfWork.SaveAsync(cancellationToken);

        var hasErrorOccurred = await _unitOfWork.SaveAsync(cancellationToken);

        return hasErrorOccurred ? (ErrorOr<ScoreBoard>)Errors.ScoreBoard.CreateError : (ErrorOr<ScoreBoard>)scoreBoard;
    }

    private ScoreBoard CreateScoreBoardFromCommandData(CreateScoreBoardCommand command, Guid gameId)
    {
        DateTimeOffset creationDate = _dateTimeProvider.Now;

        var scoreBoard = new ScoreBoard(
                Guid.NewGuid(),
                gameId,
                command.Name,
                command.MaxNumberOfScores,
                SortRule.Descending,
                creationDate,
                command.CreatedBy);

        _scoreBoardRepository.Create(scoreBoard);

        return scoreBoard;
    }

    private async Task<Game?> CheckIfGameExist(CreateScoreBoardCommand command, CancellationToken cancellationToken)
    {
        Guid.TryParse(command.GameId, out Guid gameId);

        return await _gameRepository.GetById(gameId, cancellationToken);
    }

    private async Task AddScoreBoardIdToGame(ScoreBoard scoreBoard, Game foundGame, CancellationToken cancellationToken)
    {
        foundGame.UpdateScoreBoardId(scoreBoard.Id);

        await _gameRepository.FindAndUpdate(foundGame, cancellationToken);
    }
}
