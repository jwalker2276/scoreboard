namespace Application.Persistence;

public interface IRepository<TEntity>
    where TEntity : class
{
    public void Create(TEntity entity);

    public Task<List<TEntity>> GetAll(CancellationToken cancellationToken);

    public Task<TEntity?> GetById(Guid id, CancellationToken cancellationToken);

    public void Update(TEntity entity);

    public void Delete(TEntity entity);
}