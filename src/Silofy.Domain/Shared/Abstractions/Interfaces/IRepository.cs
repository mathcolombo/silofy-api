using System.Linq.Expressions;

namespace Silofy.Domain.Shared.Abstractions.Interfaces;

public interface IRepository<T> where T : class
{
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    Task CreateAsync(IEnumerable<T> entity, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Update(IEnumerable<T> entities);
    Task<int> DeleteAsync(Expression<Func<T, bool>> whereCondition, CancellationToken cancellationToken = default);
    void Delete(T entity);
    void Delete(IEnumerable<T> entities);
    IQueryable<T> Query();
}