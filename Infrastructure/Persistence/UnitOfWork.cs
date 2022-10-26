using Application.Persistence;

namespace Infrastructure.Persistence;
internal class UnitOfWork : IUnitOfWork
{
    private bool _disposedValue;

    private readonly DatabaseContext _databaseContext;

    public UnitOfWork(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        await _databaseContext.SaveChangesAsync(cancellationToken);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _databaseContext?.Dispose();
            }

            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
