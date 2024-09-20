using System.Linq.Expressions;
using BlazeNotes.Data.Interfaces;
using BlazeNotes.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazeNotes.Data;

public class Repository<T>(BlazeAppContext context) : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void AddRange(List<T> entities)
    {
        _dbSet.AddRange(entities);
    }

    public async Task AddRangeAsync(List<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<int> DeleteBulkAsync(Expression<Func<T, bool>> expression)
    {
        var query = _dbSet.Where(expression);

        return await query.ExecuteDeleteAsync();
    }

    public void DeleteRange(List<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.AsNoTracking().ToListAsync();
    }

    public async Task<List<T>> GetAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.Where(expression).ToListAsync();
    }

    public async Task<List<T>> GetAsync(Expression<Func<T, bool>> expression, Expression<Func<T, object>>[] children)
    {
        var query = _dbSet.Where(expression);

        if (children.Length > 0)
        {
            foreach (var child in children)
            {
                query = query.Include(child);
            }
        }

        return await query.ToListAsync();
    }

    public async Task<T?> GetByGuidAsync(Guid guid)
    {
        return await _dbSet.FindAsync(guid);
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void UpdateRange(List<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }
}