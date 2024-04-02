using System.Linq.Expressions;
using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Infrastructure.DAO.Repositories;

namespace Application.Services.Impls;

public class BaseService<T, TDto>: IBaseService<T, TDto> 
    where T:Entity
    where TDto:BaseDto
{
    protected readonly IBaseRepository<T> _repository;
    protected readonly IMapper _mapper;

    public BaseService(IBaseRepository<T> repository, IMapper mapper) 
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task Add(TDto dto)
    {
        var entity = _mapper.Map<T>(dto);
        await _repository.Insert(entity);
    }

    public async Task Update(TDto dto)
    {
        var entity = await _repository.SelectFirst(x => x.Id == dto.Id);
        if (entity is not null) {
            _mapper.Map(dto, entity);
            await _repository.Update(entity);
        }
    }

    public async Task Delete(int id)
    {
        var entity = await _repository.SelectFirst(x => x.Id == id);
        if (entity != null)
        {
            await _repository.Delete(entity);
            await _repository.SaveChanges();
        }
    }

    public async Task<ICollection<TDto>> GetAll(Expression<Func<T, bool>> expression)
    {
        var entities = await _repository.Select(expression);
        return _mapper.Map<ICollection<TDto>>(entities);
    }

    public async Task<TDto?> Get(Expression<Func<T, bool>> expression)
    {
        var entity = await _repository.SelectFirst(expression);
        return _mapper.Map<TDto?>(entity);
    }
}
