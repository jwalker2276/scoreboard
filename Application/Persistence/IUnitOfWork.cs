namespace Application.Persistence;

public interface IUnitOfWork : IDisposable
{
    public Task SaveAsync(CancellationToken cancellationToken);
}
