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

    public async Task<bool> SaveAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _databaseContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception)
        {
            // TODO: Log exception
            return true;
        }

        return false;
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
