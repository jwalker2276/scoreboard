using Application.Services.GameService.Common;
using MediatR;

namespace Application.Services.GameService.Commands;

public class CreateGameCommand : IRequest<GameResponse>
{
    public string Name { get; init; } = String.Empty;
    
    public string CreatedBy { get; init; } = String.Empty;
}