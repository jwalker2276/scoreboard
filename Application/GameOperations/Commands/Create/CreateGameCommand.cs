using Domain.GameModels.Entities;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Commands.Create;

public class CreateGameCommand : IRequest<ErrorOr<Game>>
{
    public string Name { get; init; }

    public string CreatedBy { get; init; }

    public CreateGameCommand(string name, string createdBy)
    {
        Name = name;
        CreatedBy = createdBy;
    }
}