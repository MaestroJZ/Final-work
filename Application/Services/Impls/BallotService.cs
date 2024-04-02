using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Infrastructure.DAO.Repositories;

namespace Application.Services.Impls;

public class BallotService : BaseService<Ballot, BallotDto>, IBallotService
{
    public BallotService(IBaseRepository<Ballot> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}