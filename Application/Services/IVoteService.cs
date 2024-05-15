using Application.DTOs;
using Domain.Models;

namespace Application.Services;

public interface IVoteService : IBaseService<Vote, VoteDto>;