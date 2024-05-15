using Application.Services;
using Application.Services.Impls;
using Domain.Models;
using Infrastructure.DAO;
using Infrastructure.DAO.Repositories;
using Infrastructure.DAO.Repositories.Impls;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Configs;

public static class ModuleConfig
{
    public static void ConfigureModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddTransient(typeof(IBaseService<,>), typeof(BaseService<,>));
        services.AddScoped<DbContext, DataContext>();
        services.AddScoped<ICandidateService, CandiateService>();
        services.AddScoped<IVoteService, VoteService>();
        services.AddScoped<IVoterService, VoterService>();
        services.AddScoped<IElectionService, ElectionService>();
        services.AddScoped<IHashPasswordService, HashPasswordService>();
        services.AddScoped<IUserService, UserService>();

        services.Configure<BlockchainSettings>(configuration.GetSection("Blockchain"));

        services.AddScoped<IBlockchainService, BlockchainService>();
        services.AddScoped<ITransactionService, TransactionService>();
    }
}