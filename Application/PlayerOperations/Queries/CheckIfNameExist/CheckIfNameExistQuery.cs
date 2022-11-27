using Domain.PlayerModels.Entities;
using ErrorOr;
using MediatR;

namespace Application.PlayerOperations.Queries.CheckIfNameExist;

public class CheckIfNameExistQuery : IRequest<ErrorOr<Player>>
{
    public string Name { get; init; }

    public CheckIfNameExistQuery(string name)
    {
        Name = name;
    }
}
