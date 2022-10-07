using Domain.Entities;
using MediatR;

namespace Application.Game.Commands;

public class CreateGameCommand : IRequest<StandardGame>
{
    public CreateGameCommand(string name, string createdBy)
    {
        Name = name;
        CreatedBy = createdBy;
    }
    
    public string Name { get; init; }
    
    public string CreatedBy { get; init; }
}