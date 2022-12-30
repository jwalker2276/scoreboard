using Domain.ScoreModels.Entities;

namespace Application.Persistence;

public interface IScoreRepository : IRepository<Score>, IScoreBoardScoresSearch
{
}
