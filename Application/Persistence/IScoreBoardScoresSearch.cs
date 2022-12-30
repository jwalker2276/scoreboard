using Domain.ScoreBoardModels.Entities;
using Domain.ScoreModels.Entities;

namespace Application.Persistence;

public interface IScoreBoardScoresSearch
{
    Task<List<Score>> GetScoreBoardScores(ScoreBoard scoreboard, CancellationToken cancellation);
}
