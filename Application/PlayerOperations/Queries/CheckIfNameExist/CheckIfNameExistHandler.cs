using Application.Persistence;
using Application.Services;
using Domain.PlayerModels.Entities;
using ErrorOr;
using MediatR;
using System.Linq.Expressions;

namespace Application.PlayerOperations.Queries.CheckIfNameExist;

public sealed class CheckIfNameExistHandler : IRequestHandler<CheckIfNameExistQuery, ErrorOr<Player?>>
{
    private readonly IPlayerRepository _playerRepository;

    private readonly IBlackListService _blackListService;

    public CheckIfNameExistHandler(IPlayerRepository playerRepository, IBlackListService blackListService)
    {
        _playerRepository = playerRepository;
        _blackListService = blackListService;
    }

    public async Task<ErrorOr<Player?>> Handle(CheckIfNameExistQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<Player, bool>> filter = p => p.PreferredPlayerName == query.Name;

        Player? foundPlayer = await _playerRepository.GetByName(filter, cancellationToken);

        if (foundPlayer is not null)
        {
            return foundPlayer;
        }

        var isNameApproved = await _blackListService.IsWordApproved(query.Name, cancellationToken);

        var newMockPlayer = new Player(Guid.Empty, "", query.Name, isNameApproved, DateTimeOffset.MinValue, "");

        return newMockPlayer;
    }
}
