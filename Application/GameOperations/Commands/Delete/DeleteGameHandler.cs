using Application.Persistence;
using Domain.Entities;
using Domain.Errors;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Commands.Delete;

public sealed class DeleteGameHandler : IRequestHandler<DeleteGameCommand, ErrorOr<Game>>
{
    private readonly IRepository<Game> _repository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteGameHandler(IRepository<Game> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Game>> Handle(DeleteGameCommand command, CancellationToken cancellationToken)
    {
        Guid.TryParse(command.Id, out Guid gameId);

        Game? game = await _repository.GetById(gameId, cancellationToken);

        if (game is null) return Errors.Game.NotFound;

        _repository.Delete(game);

        await _unitOfWork.SaveAsync(cancellationToken);

        return game;
    }
}
