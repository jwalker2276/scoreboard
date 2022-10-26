namespace Application.Persistence;

public interface IRepository<TEntity>
    where TEntity : class
{
    public void Create(TEntity entity);

    public IEnumerable<TEntity> GetAll();

    public TEntity? GetById(Guid id);

    public void Update(TEntity entity);

    public void Delete(TEntity entity);
}