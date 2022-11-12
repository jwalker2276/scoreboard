using Domain.GameModels.Entities;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Queries.GetAll;
public class GetAllGamesQuery : IRequest<ErrorOr<List<Game>>>
{
}
