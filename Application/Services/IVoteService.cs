using Application.DTOs;
using Application.Services.Impls;
using AutoMapper;
using Domain.Models;
using Infrastructure.DAO.Repositories;

namespace Application.Services;
public interface IVoteService : IBaseService<Vote, VoteDto>
{
}

public class VoteService : BaseService<Vote, VoteDto>, IVoteService
{
    public VoteService(IBaseRepository<Vote> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
