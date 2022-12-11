using Application.Common.Dates;
using Application.Persistence;
using Application.Services;
using Domain.Errors;
using Domain.PlayerModels.Entities;
using Domain.PlayerModels.ValueObjects;
using Domain.ScoreBoardModels.Entities;
using Domain.ScoreModels.Entities;
using ErrorOr;
using MediatR;
using System.Linq.Expressions;

namespace Application.ScoreOperations.Commands;

public sealed class CreateScoreHandler : IRequestHandler<CreateScoreCommand, ErrorOr<Score>>
{
    private readonly IRepository<Score> _scoreRepository;

    private readonly IPlayerRepository _playerRepository;

    private readonly IRepository<ScoreBoard> _scoreBoardRepository;

    private readonly IUnitOfWork _unitOfWork;

    private readonly IBlackListService _blackListService;

    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateScoreHandler(IRepository<Score> scoreRepository,
                              IPlayerRepository playerRepository,
                              IRepository<ScoreBoard> scoreBoardRepository,
                              IUnitOfWork unitOfWork,
                              IBlackListService blackListService,
                              IDateTimeProvider dateTimeProvider)
    {
        _scoreRepository = scoreRepository;
        _playerRepository = playerRepository;
        _scoreBoardRepository = scoreBoardRepository;
        _unitOfWork = unitOfWork;
        _blackListService = blackListService;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<Score>> Handle(CreateScoreCommand request, CancellationToken cancellationToken)
    {
        ScoreBoard? scoreBoard = await DoesScoreBoardExist(request.ScoreBoardId, cancellationToken);

        if (scoreBoard is null) return Errors.ScoreBoard.NotFound;

        Player? existingPlayer = await CheckForExistingPlayer(request.PlayerDetails, cancellationToken);

        if (existingPlayer is null)
        {
            var isNameAllowed = await CheckPlayerNameDetails(request, cancellationToken);

            return !isNameAllowed ? (ErrorOr<Score>)Errors.Player.PlayerNameInvalid : await CreateScoreForNewPlayer(request, scoreBoard, cancellationToken);
        }

        return await CreateScoreForExistingPlayer(request, scoreBoard, existingPlayer, cancellationToken);
    }

    private async Task<ScoreBoard?> DoesScoreBoardExist(string scoreBoardId, CancellationToken cancellationToken)
    {
        Guid.TryParse(scoreBoardId, out Guid scoreBoardGuid);

        return await _scoreBoardRepository.GetById(scoreBoardGuid, cancellationToken);
    }

    private async Task<Player?> CheckForExistingPlayer(PlayerName playerDetails, CancellationToken cancellationToken)
    {
        Expression<Func<Player, bool>> filter = p => p.PreferredPlayerName == playerDetails.PreferredPlayerName || p.DefaultPlayerName == playerDetails.DefaultPlayerName;

        return await _playerRepository.GetByName(filter, cancellationToken);
    }

    private async Task<bool> CheckPlayerNameDetails(CreateScoreCommand request, CancellationToken cancellationToken)
    {
        return string.IsNullOrWhiteSpace(request.PlayerDetails.PreferredPlayerName)
            ? true
            : await _blackListService.IsWordApproved(request.PlayerDetails.PreferredPlayerName, cancellationToken);
    }

    private async Task<ErrorOr<Score>> CreateScoreForNewPlayer(CreateScoreCommand request, ScoreBoard scoreBoard, CancellationToken cancellationToken)
    {
        DateTimeOffset creationDate = _dateTimeProvider.Now;

        var newPlayer = new Player(Guid.NewGuid(), "", "", true, creationDate, request.CreatedBy);

        _playerRepository.Create(newPlayer);

        var score = new Score(Guid.NewGuid(), request.Value, scoreBoard.Id, newPlayer.Id, creationDate, request.CreatedBy);

        _scoreRepository.Create(score);

        var hasErrorOccurred = await _unitOfWork.SaveAsync(cancellationToken);

        return hasErrorOccurred ? (ErrorOr<Score>)Errors.Score.CreateError : (ErrorOr<Score>)score;
    }

    private async Task<ErrorOr<Score>> CreateScoreForExistingPlayer(CreateScoreCommand request, ScoreBoard scoreBoard, Player existingPlayer, CancellationToken cancellationToken)
    {
        DateTimeOffset creationDate = _dateTimeProvider.Now;

        var score = new Score(Guid.NewGuid(), request.Value, scoreBoard.Id, existingPlayer.Id, creationDate, request.CreatedBy);

        _scoreRepository.Create(score);

        var hasErrorOccurred = await _unitOfWork.SaveAsync(cancellationToken);

        return hasErrorOccurred ? (ErrorOr<Score>)Errors.Score.CreateError : (ErrorOr<Score>)score;
    }
}
