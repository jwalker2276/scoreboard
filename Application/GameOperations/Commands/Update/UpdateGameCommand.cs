using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Commands.Update;

public sealed class UpdateGameCommand : IRequest<ErrorOr<Game>>
{
    public string Id { get; init; } = string.Empty;

    public string Name { get; init; } = string.Empty;

    public bool IsActive { get; init; } = true;
}
