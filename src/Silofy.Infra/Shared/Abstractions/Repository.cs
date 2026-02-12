using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Silofy.Domain.Shared.Abstractions.Interfaces;
using Silofy.Infra.Configs.Contexts;

namespace Silofy.Infra.Shared.Abstractions;

public class Repository<T>(SilofyDbContext context) : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default) => await _dbSet.AddAsync(entity, cancellationToken);

    public async Task CreateAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default) => await _dbSet.AddRangeAsync(entities, cancellationToken);
    
    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default) => await _dbSet.FindAsync(id, cancellationToken);
    
    public void Update(T entity) => _dbSet.Update(entity);
    
    public void Update(IEnumerable<T> entities) => _dbSet.UpdateRange(entities);
    
    public async Task<int> DeleteAsync(Expression<Func<T, bool>> whereCondition, CancellationToken cancellationToken = default) => await _dbSet.Where(whereCondition).ExecuteDeleteAsync(cancellationToken);
    
    public void Delete(T entity) => _dbSet.Remove(entity);
    
    public void Delete(IEnumerable<T> entities) => _dbSet.RemoveRange(entities);
    
    public IQueryable<T> Query() => _dbSet.AsNoTracking();
}