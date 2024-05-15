using System.Linq.Expressions;

namespace Infrastructure.DAO.Repositories;

public interface IBaseRepository<T>
{
    Task Insert(T entity);
    Task Update(T entity);
    Task Delete(T entity);
    Task<ICollection<T>> Select(Expression<Func<T, bool>> expression);
    Task<T?> SelectFirst(Guid id);
    Task<T?> SelectFirst(Expression<Func<T, bool>> expression);
    Task SaveChanges();
}
