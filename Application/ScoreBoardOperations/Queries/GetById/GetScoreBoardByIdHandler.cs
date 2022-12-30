using Application.Persistence;
using Domain.Errors;
using Domain.ScoreBoardModels.Entities;
using Domain.ScoreModels.Entities;
using ErrorOr;
using MediatR;

namespace Application.ScoreBoardOperations.Queries.GetById;

public class GetScoreBoardByIdHandler : IRequestHandler<GetScoreBoardByIdQuery, ErrorOr<ScoreBoard>>
{
    private readonly IRepository<ScoreBoard> _scoreBoardRepository;

    private readonly IScoreRepository _scoreRepository;

    public GetScoreBoardByIdHandler(IRepository<ScoreBoard> scoreBoardRepository, IScoreRepository scoreRepository)
    {
        _scoreBoardRepository = scoreBoardRepository;
        _scoreRepository = scoreRepository;
    }

    public async Task<ErrorOr<ScoreBoard>> Handle(GetScoreBoardByIdQuery request, CancellationToken cancellationToken)
    {
        Guid.TryParse(request.Id, out Guid scoreBoardId);

        ScoreBoard? scoreBoard = await _scoreBoardRepository.GetById(scoreBoardId, cancellationToken);

        if (scoreBoard is null)
        {
            return Errors.ScoreBoard.NotFound;
        }

        List<Score> scores = await _scoreRepository.GetScoreBoardScores(scoreBoard, cancellationToken);

        if (scores.Any())
        {
            scoreBoard.Scores = scores;
        }

        return scoreBoard;
    }
}
