using System.Numerics;
using Application.DTOs;

namespace Application.Services;

public interface IBlockchainService
{
    Task<string> VoteAsync(Guid id);
}