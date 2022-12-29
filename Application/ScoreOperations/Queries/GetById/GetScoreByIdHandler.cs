using Application.Persistence;
using Domain.Errors;
using Domain.ScoreModels.Entities;
using ErrorOr;
using MediatR;

namespace Application.ScoreOperations.Queries.GetById;

public sealed class GetScoreByIdHandler : IRequestHandler<GetScoreByIdQuery, ErrorOr<Score>>
{
    private readonly IRepository<Score> _scoreRepository;

    public GetScoreByIdHandler(IRepository<Score> scoreRepository)
    {
        _scoreRepository = scoreRepository;
    }

    public async Task<ErrorOr<Score>> Handle(GetScoreByIdQuery query, CancellationToken cancellationToken)
    {
        Guid.TryParse(query.Id, out Guid scoreId);

        Score? score = await _scoreRepository.GetById(scoreId, cancellationToken);

        return score is null ? Errors.Score.NotFound : score;
    }
}
