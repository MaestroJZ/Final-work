using Application.Services;
using Application.Services.Impls;
using Infrastructure.DAO;
using Infrastructure.DAO.Repositories;
using Infrastructure.DAO.Repositories.Impls;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Configs;

public static class ModuleConfig
{
    public static void ConfigureModule(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddTransient(typeof(IBaseService<,>), typeof(BaseService<,>));
        services.AddScoped<IHashPasswordService, HashPasswordService>();
        services.AddScoped<DbContext, DataContext>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICandidateService, CandiateService>();
        services.AddScoped<IVoterService, VoterService>();
        services.AddScoped<IElectionService, ElectionService>();
    }
}