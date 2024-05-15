using System.Linq.Expressions;

namespace Application.Services;

public interface IBaseService<T, TDto>
{
    Task<Guid> Add(TDto dto);
    Task Update(TDto dto);
    Task Delete(Guid id);
    Task<ICollection<TDto>> GetAll(Expression<Func<T, bool>> expression);
    Task<TDto?> Get(Guid id);
}
