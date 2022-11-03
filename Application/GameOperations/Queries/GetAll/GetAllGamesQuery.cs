using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.GameOperations.Queries.GetAll;
public class GetAllGamesQuery : IRequest<ErrorOr<List<Game>>>
{
}
