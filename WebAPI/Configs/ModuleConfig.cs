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
        services.AddScoped<DbContext, DataContext>();
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddTransient(typeof(IBaseService<,>), typeof(BaseService<,>));
    }

}