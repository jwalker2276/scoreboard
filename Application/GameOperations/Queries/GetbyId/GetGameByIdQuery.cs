using Domain.GameModels.Entities;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Queries.GetbyId;

public class GetGameByIdQuery : IRequest<ErrorOr<Game>>
{
    public string Id { get; init; }

    public GetGameByIdQuery(string id)
    {
        Id = id;
    }
}
