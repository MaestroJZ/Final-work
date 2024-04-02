using Application.DTOs;
using Application.Services.Impls;
using AutoMapper;
using Domain.Models;
using Infrastructure.DAO.Repositories;

namespace Application.Services;

public interface IVotingService : IBaseService<Voting, VotingDto>
{
    Task<bool> Vote(int votingId, int ballotOptionId, string fullName, string phoneNumber);
}