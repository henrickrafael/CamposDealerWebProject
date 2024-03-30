using System.Linq.Expressions;

namespace CamposDealerWebProject.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null);

    Task<T> Get(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);

    Task Update(T entity);

    Task Delete(T entity);

    Task<int> Count();
}
