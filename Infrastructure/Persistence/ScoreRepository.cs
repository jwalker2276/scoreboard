using Application.Persistence;
using Domain.ScoreBoardModels.Entities;
using Domain.ScoreModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ScoreRepository : IScoreRepository
{
    private readonly DatabaseContext _databaseContext;

    private readonly DbSet<Score> _dbScores;

    public ScoreRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _dbScores = _databaseContext.Set<Score>();
    }

    public void Create(Score entity)
    {
        _dbScores.Add(entity);
    }

    public Task<Score?> FindAndDelete(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Score?> FindAndUpdate(Score updatedEntity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<List<Score>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<Score?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _dbScores.Include(score => score.Player).FirstOrDefaultAsync(score => score.Id == id, cancellationToken);
    }

    public async Task<List<Score>> GetScoreBoardScores(ScoreBoard scoreboard, CancellationToken cancellation)
    {
        return await _dbScores
            .Include(score => score.Player)
            .Where(score => score.GameId == scoreboard.GameId)
            .OrderByDescending(score => score.Value)
            .Take(scoreboard.MaxNumberOfScores)
            .ToListAsync(cancellation);
    }
}
