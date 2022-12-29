using Application.Persistence;
using Domain.ScoreBoardModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ScoreBoardRepository : IRepository<ScoreBoard>
{
    private readonly DatabaseContext _databaseContext;

    private readonly DbSet<ScoreBoard> _dbScoreBoards;

    public ScoreBoardRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _dbScoreBoards = _databaseContext.Set<ScoreBoard>();
    }

    public void Create(ScoreBoard entity)
    {
        _dbScoreBoards.Add(entity);
    }
    public Task<List<ScoreBoard>> GetAll(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<ScoreBoard?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await _dbScoreBoards
            .FirstOrDefaultAsync(scoreboard => scoreboard.Id == id, cancellationToken);

    }
    public Task<ScoreBoard?> FindAndUpdate(ScoreBoard updatedEntity, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ScoreBoard?> FindAndDelete(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
