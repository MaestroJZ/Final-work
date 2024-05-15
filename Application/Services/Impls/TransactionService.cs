using Application.DTOs;
using AutoMapper;
using Domain.Models;
using Infrastructure.DAO.Repositories;

namespace Application.Services.Impls;

public class TransactionService : BaseService<Transaction, TransactionDto>, ITransactionService
{
    /// <inheritdoc />
    public TransactionService(IBaseRepository<Transaction> repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
