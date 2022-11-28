using Application.Persistence;
using Domain.PlayerModels.Entities;
using ErrorOr;
using MediatR;
using System.Linq.Expressions;

namespace Application.PlayerOperations.Queries.CheckIfNameExist;

public sealed class CheckIfNameExistHandler : IRequestHandler<CheckIfNameExistQuery, ErrorOr<Player?>>
{
    private readonly IPlayerRepository _playerRepository;

    public CheckIfNameExistHandler(IPlayerRepository playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<ErrorOr<Player?>> Handle(CheckIfNameExistQuery query, CancellationToken cancellationToken)
    {
        Expression<Func<Player, bool>> filter = p => p.PreferredPlayerName == query.Name;

        return await _playerRepository.GetByName(filter, cancellationToken);
    }
}
