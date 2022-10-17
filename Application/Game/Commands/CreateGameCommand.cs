using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Game.Commands;

public class CreateGameCommand : IRequest<ErrorOr<StandardGame>>
{
    public string Name { get; init; }

    public string CreatedBy { get; init; }

    public CreateGameCommand(string name, string createdBy)
    {
        Name = name;
        CreatedBy = createdBy;
    }
}