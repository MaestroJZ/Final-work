using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Infrastructure.DAO.Repositories;

namespace Application.Services.Impls;

public class ElectionService : BaseService<Election, ElectionDto>, IElectionService
{
    /// <inheritdoc />
    public ElectionService(IBaseRepository<Election> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}