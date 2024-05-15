using Application.DTOs;
using Domain.Models;

namespace Application.Services;

public interface IElectionService : IBaseService<Election, ElectionDto>;