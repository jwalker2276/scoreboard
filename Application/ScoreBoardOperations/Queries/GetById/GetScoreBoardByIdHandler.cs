using Application.Persistence;
using Domain.Errors;
using Domain.ScoreBoardModels.Entities;
using ErrorOr;
using MediatR;

namespace Application.ScoreBoardOperations.Queries.GetById;

public class GetScoreBoardByIdHandler : IRequestHandler<GetScoreBoardByIdQuery, ErrorOr<ScoreBoard>>
{
    private readonly IRepository<ScoreBoard> _scoreBoardRepository;

    public GetScoreBoardByIdHandler(IRepository<ScoreBoard> scoreBoardRepository)
    {
        _scoreBoardRepository = scoreBoardRepository;
    }

    public async Task<ErrorOr<ScoreBoard>> Handle(GetScoreBoardByIdQuery request, CancellationToken cancellationToken)
    {
        Guid.TryParse(request.Id, out Guid scoreBoardId);

        ScoreBoard? scoreBoard = await _scoreBoardRepository.GetById(scoreBoardId, cancellationToken);

        return scoreBoard is null ? Errors.ScoreBoard.NotFound : scoreBoard;
    }
}
