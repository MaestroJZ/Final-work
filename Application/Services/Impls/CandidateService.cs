using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Infrastructure.DAO.Repositories;

namespace Application.Services.Impls;

public class CandiateService : BaseService<Candidate, CandidateDto>, ICandidateService
{
    /// <inheritdoc />
    public CandiateService(IBaseRepository<Candidate> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}