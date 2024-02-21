using CamposDealerWebProject.Context;
using CamposDealerWebProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace CamposDealerWebProject.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task Add(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task<int> Count()
    {
        return await _dbSet.AsNoTracking().CountAsync();
    }

    public Task Delete(T entity)
    {
        _dbSet.Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<T> Get(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null)
    {
        if (predicate is not null)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        return _dbSet.AsNoTracking().AsEnumerable();
    }

    public Task Update(T entity)
    {
        _dbSet.Attach(entity);
        ((IObjectContextAdapter)_context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, System.Data.Entity.EntityState.Modified);

        return Task.CompletedTask;
    }
}
