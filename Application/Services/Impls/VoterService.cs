using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Infrastructure.DAO.Repositories;

namespace Application.Services.Impls;

public class VoterService : BaseService<Voter, VoterDto>, IVoterService
{
    public VoterService(IBaseRepository<Voter> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}