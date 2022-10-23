using ErrorOr;
using MediatR;

namespace Application.GameOperations.Commands;

public class CreateGameCommand : IRequest<ErrorOr<Domain.Entities.Game>>
{
    public string Name { get; init; }

    public string CreatedBy { get; init; }

    public CreateGameCommand(string name, string createdBy)
    {
        Name = name;
        CreatedBy = createdBy;
    }
}