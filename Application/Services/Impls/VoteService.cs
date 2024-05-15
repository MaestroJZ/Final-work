using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Infrastructure.DAO.Repositories;

namespace Application.Services.Impls;

public class VoteService : BaseService<Vote, VoteDto>, IVoteService
{
    /// <inheritdoc />
    public VoteService(IBaseRepository<Vote> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}