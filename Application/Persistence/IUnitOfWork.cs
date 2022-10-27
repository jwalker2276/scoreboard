namespace Application.Persistence;

public interface IUnitOfWork : IDisposable
{
    public Task<bool> SaveAsync(CancellationToken cancellationToken);
}
