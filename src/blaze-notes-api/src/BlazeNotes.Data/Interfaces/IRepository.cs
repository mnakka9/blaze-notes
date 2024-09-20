using System.Linq.Expressions;

namespace BlazeNotes.Data.Interfaces;

public interface IRepository<T> where T : class
{
    void Add(T entity);

    Task AddAsync(T entity);

    void Delete(T entity);

    void Update(T entity);

    void AddRange(List<T> entities);
    Task AddRangeAsync(List<T> entities);
    void UpdateRange(List<T> entities);
    void DeleteRange(List<T> entities);

    Task<T?> GetByIdAsync(int id);

    Task<T?> GetByGuidAsync(Guid guid);

    Task<List<T>> GetAllAsync();

    Task<List<T>> GetAsync(Expression<Func<T, bool>> expression);
    Task<List<T>> GetAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>>[] children);

    Task<int> DeleteBulkAsync(Expression<Func<T, bool>> expression);
}
