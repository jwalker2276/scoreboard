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
        ErrorOr<object?> playerCheckDetails = await CheckPlayerDetails(request.PlayerDetails, cancellationToken);

        ScoreBoard? scoreBoard = await DoesScoreBoardExist(request.ScoreBoardId, cancellationToken);

        Player? existingPlayer = (Player?)playerCheckDetails.Value ?? null;

        return scoreBoard is null ? (ErrorOr<Score>)Errors.ScoreBoard.NotFound : await CreateEntitiesAndSave(request, scoreBoard, existingPlayer);
    }

    private async Task<ErrorOr<object?>> CheckPlayerDetails(PlayerName playerDetails, CancellationToken cancellationToken)
    {
        Expression<Func<Player, bool>> filter = p => p.PreferredPlayerName == playerDetails.PreferredPlayerName;

        // TODO: Call new method to check both default name and preferred names.
        Player? foundPlayer = await _playerRepository.GetByName(filter, cancellationToken);

        if (foundPlayer is not null) return foundPlayer;

        // TODO: If player preferred name is empty, bypass this.
        if (string.IsNullOrWhiteSpace(playerDetails.PreferredPlayerName)) return foundPlayer;

        // TODO: If player is not found check name rules.
        var isNameApproved = await _blackListService.IsWordApproved(playerDetails.PreferredPlayerName, cancellationToken);

        // TODO: Figure out how to handle the return.
        return isNameApproved ? foundPlayer : (ErrorOr<Score>)Errors.Player.PlayerNameInvalid;
    }

    private async Task<ScoreBoard?> DoesScoreBoardExist(string scoreBoardId, CancellationToken cancellationToken)
    {
        Guid.TryParse(scoreBoardId, out Guid scoreBoardGuid);

        return await _scoreBoardRepository.GetById(scoreBoardGuid, cancellationToken);
    }

    private Task<ErrorOr<Score>> CreateEntitiesAndSave(CreateScoreCommand request, ScoreBoard scoreBoard, Player? existingPlayer)
    {
        // TODO: If existing player is null create new one entity.

        // TODO: Create score entity

        // TODO: Save changes

        // TODO: Return entity

        throw new NotImplementedException();
    }
}
