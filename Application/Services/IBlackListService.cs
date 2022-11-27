namespace Application.Services;

public interface IBlackListService
{
    public Task<bool> DoesWordExistInBlackList(string wordToCheck, CancellationToken cancellationToken);
}
