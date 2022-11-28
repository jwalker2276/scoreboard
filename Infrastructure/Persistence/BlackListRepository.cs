using Application.Services;
using Infrastructure.CustomModels;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class BlackListRepository : IBlackListService
{
    private readonly DatabaseContext _databaseContext;

    private readonly DbSet<BlackListWord> _dbBlackListWords;

    public BlackListRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
        _dbBlackListWords = _databaseContext.Set<BlackListWord>();
    }

    public async Task<bool> DoesWordExistInBlackList(string wordToCheck, CancellationToken cancellationToken)
    {
        List<BlackListWord> matches = await _dbBlackListWords.Where(words => words.NotAllowedWordOrCharacters.Contains(wordToCheck))
                                                             .ToListAsync(cancellationToken);

        return matches.Count > 0;
    }
}
