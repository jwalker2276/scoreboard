using Application.Persistence;
using Domain.PlayerModels.Entities;
using ErrorOr;
using MediatR;

namespace Application.PlayerOperations.Queries.CheckIfNameExist;

public sealed class CheckIfNameExistHandler : IRequestHandler<CheckIfNameExistQuery, ErrorOr<Player>>
{
    private readonly IRepository<Player> _playerRepository;

    public CheckIfNameExistHandler(IRepository<Player> playerRepository)
    {
        _playerRepository = playerRepository;
    }

    public async Task<ErrorOr<Player>> Handle(CheckIfNameExistQuery query, CancellationToken cancellationToken)
    {
        return new Player(Guid.Empty, "", "", false, new DateTimeOffset(), "");
    }
}
