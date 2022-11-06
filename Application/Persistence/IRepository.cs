namespace Application.Persistence;

public interface IRepository<TEntity>
    where TEntity : class
{
    public void Create(TEntity entity);

    public Task<List<TEntity>> GetAll(CancellationToken cancellationToken);

    public Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken);

    public Task<TEntity?> FindAndUpdate(TEntity updatedEntity, CancellationToken cancellationToken);

    public Task<TEntity?> FindAndDelete(Guid id, CancellationToken cancellationToken);
}