using Application.DTOs;
using Domain.Models;

namespace Application.Services;

public interface ITransactionService : IBaseService<Transaction, TransactionDto>;