using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Game.Commands;

public class CreateGameCommand : IRequest<ErrorOr<StandardGame>>
{
    public CreateGameCommand(string name, string createdBy)
    {
        Name = name;
        CreatedBy = createdBy;
    }

    public string Name { get; init; }

    public string CreatedBy { get; init; }
}