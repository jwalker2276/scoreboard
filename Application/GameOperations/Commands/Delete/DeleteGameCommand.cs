using Domain.Entities.Game;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Commands.Delete;

public sealed class DeleteGameCommand : IRequest<ErrorOr<Game>>
{
    public string Id { get; init; }

    public DeleteGameCommand(string id)
    {
        Id = id;
    }
}
