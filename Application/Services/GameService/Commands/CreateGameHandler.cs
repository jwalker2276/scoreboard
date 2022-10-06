using Application.Services.GameService.Common;
using MediatR;

namespace Application.Services.GameService.Commands;

public class CreateGameHandler : IRequestHandler<CreateGameCommand, GameResponse>
{
    public Task<GameResponse> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        // Call database interface

        return Task.FromResult(new GameResponse()
        {
            Id = new Guid(),
            Name = request.Name,
            IsActive = true,
            CreationDate = DateTime.Today,
            CreatedBy = request.CreatedBy
        });
    }
}