using System.Linq.Expressions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DAO.Repositories.Impls;

public class BaseRepository<T>: IBaseRepository<T> where T:Entity
{
    private readonly DbContext _dbContext;

    public BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task Insert(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await SaveChanges();
    }

    public async Task Update(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await SaveChanges();
    }

    public async Task Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await SaveChanges();
    }

    public async Task<ICollection<T>> Select(Expression<Func<T, bool>> expression)
    {
        return await _dbContext.Set<T>().Where(expression).ToListAsync();
    }

    public async Task<T?> SelectFirst(Guid id)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <inheritdoc />
    public async Task<T?> SelectFirst(Expression<Func<T, bool>> expression)
    {
        return await _dbContext.Set<T>().FirstOrDefaultAsync(expression);
    }

    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
}
