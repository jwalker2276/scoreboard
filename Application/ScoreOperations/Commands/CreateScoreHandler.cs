using Application.Common.Dates;
using Application.Persistence;
using Application.Services;
using Domain.Errors;
using Domain.GameModels.Entities;
using Domain.PlayerModels.Entities;
using Domain.PlayerModels.ValueObjects;
using Domain.ScoreModels.Entities;
using ErrorOr;
using MediatR;
using System.Linq.Expressions;

namespace Application.ScoreOperations.Commands;

public sealed class CreateScoreHandler : IRequestHandler<CreateScoreCommand, ErrorOr<Score>>
{
    private readonly IScoreRepository _scoreRepository;

    private readonly IPlayerRepository _playerRepository;

    private readonly IRepository<Game> _gameRespository;

    private readonly IUnitOfWork _unitOfWork;

    private readonly IBlackListService _blackListService;

    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateScoreHandler(IScoreRepository scoreRepository,
                              IPlayerRepository playerRepository,
                              IRepository<Game> gameRepository,
                              IUnitOfWork unitOfWork,
                              IBlackListService blackListService,
                              IDateTimeProvider dateTimeProvider)
    {
        _scoreRepository = scoreRepository;
        _playerRepository = playerRepository;
        _gameRespository = gameRepository;
        _unitOfWork = unitOfWork;
        _blackListService = blackListService;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<ErrorOr<Score>> Handle(CreateScoreCommand request, CancellationToken cancellationToken)
    {
        Game? game = await DoesGameExist(request.GameId, cancellationToken);

        if (game is null) return Errors.Game.NotFound;

        Player? existingPlayer = await CheckForExistingPlayer(request.PlayerDetails, cancellationToken);

        if (existingPlayer is null)
        {
            var isNameAllowed = await CheckPlayerNameDetails(request, cancellationToken);

            return !isNameAllowed ? (ErrorOr<Score>)Errors.Player.PlayerNameInvalid : await CreateScoreForNewPlayer(request, game, cancellationToken);
        }

        return await CreateScoreForExistingPlayer(request, game, existingPlayer, cancellationToken);
    }

    private async Task<Game?> DoesGameExist(string id, CancellationToken cancellationToken)
    {
        Guid.TryParse(id, out Guid gameId);

        return await _gameRespository.GetById(gameId, cancellationToken);
    }

    private async Task<Player?> CheckForExistingPlayer(PlayerName playerDetails, CancellationToken cancellationToken)
    {
        Expression<Func<Player, bool>> filter = p => p.PreferredPlayerName == playerDetails.PreferredPlayerName;

        return await _playerRepository.GetByName(filter, cancellationToken);
    }

    private async Task<bool> CheckPlayerNameDetails(CreateScoreCommand request, CancellationToken cancellationToken)
    {
        return string.IsNullOrWhiteSpace(request.PlayerDetails.PreferredPlayerName)
            ? true
            : await _blackListService.IsWordApproved(request.PlayerDetails.PreferredPlayerName, cancellationToken);
    }

    private async Task<ErrorOr<Score>> CreateScoreForNewPlayer(CreateScoreCommand request, Game game, CancellationToken cancellationToken)
    {
        DateTimeOffset creationDate = _dateTimeProvider.Now;

        var newPlayer = new Player(Guid.NewGuid(), request.PlayerDetails.PreferredPlayerName, true, creationDate, request.CreatedBy);

        _playerRepository.Create(newPlayer);

        var score = new Score(Guid.NewGuid(), request.Value, game.Id, newPlayer.Id, creationDate, request.CreatedBy);

        _scoreRepository.Create(score);

        var hasErrorOccurred = await _unitOfWork.SaveAsync(cancellationToken);

        return hasErrorOccurred ? (ErrorOr<Score>)Errors.Score.CreateError : (ErrorOr<Score>)score;
    }

    private async Task<ErrorOr<Score>> CreateScoreForExistingPlayer(CreateScoreCommand request, Game game, Player existingPlayer, CancellationToken cancellationToken)
    {
        DateTimeOffset creationDate = _dateTimeProvider.Now;

        var score = new Score(Guid.NewGuid(), request.Value, game.Id, existingPlayer.Id, creationDate, request.CreatedBy);

        _scoreRepository.Create(score);

        var hasErrorOccurred = await _unitOfWork.SaveAsync(cancellationToken);

        return hasErrorOccurred ? (ErrorOr<Score>)Errors.Score.CreateError : (ErrorOr<Score>)score;
    }
}
