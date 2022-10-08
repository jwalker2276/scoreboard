using Domain.Entities;
using MediatR;

namespace Application.Game.Commands;

public class CreateGameHandler : IRequestHandler<CreateGameCommand, StandardGame>
{
    public async Task<StandardGame> Handle(CreateGameCommand command, CancellationToken cancellationToken)
    {
        // Call database interface
        var mockResponse = Task.FromResult(new StandardGame(Guid.NewGuid(), command.Name, true, command.CreatedBy));

        return await mockResponse;
    }
}