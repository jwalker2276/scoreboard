namespace Application.Services;

public interface IBlackListService
{
    public Task<bool> IsWordApproved(string wordToCheck, CancellationToken cancellationToken);
}
