using Application.DTOs;
using Application.Services.Impls;
using AutoMapper;
using Domain.Models;
using Infrastructure.DAO.Repositories;

namespace Application.Services;

public interface IBallotService : IBaseService<Ballot, BallotDto>
{
}