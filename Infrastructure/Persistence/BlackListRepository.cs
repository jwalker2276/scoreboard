using Application.Services;
using Infrastructure.CustomModels;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;
public class BlackListRepository : IBlackListService
{
    private readonly DatabaseContext _databaseContext;

    private readonly DbSet<BlackListWord> _dbBlackList;

    public BlackListRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public Task<bool> DoesWordExistInBlackList(string wordToCheck, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
