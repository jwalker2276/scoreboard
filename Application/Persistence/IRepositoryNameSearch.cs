using System.Linq.Expressions;

namespace Application.Persistence;

public interface IRepositoryNameSearch<TEntity>
    where TEntity : class
{
    Task<TEntity?> GetByName(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken);
}
