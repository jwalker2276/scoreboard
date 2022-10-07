using Domain.Entities;
using MediatR;

namespace Application.Game.Commands;

public class CreateGameHandler : IRequestHandler<CreateGameCommand, StandardGame>
{
    public Task<StandardGame> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        // Call database interface
        var mockResponse = new StandardGame(Guid.NewGuid(), command.Name, true, command.CreatedBy);

        return Task.FromResult(mockResponse);
    }
}