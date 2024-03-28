using Application.Mapping;
using AutoMapper;

namespace WebAPI.Configs;

public static class AutoMapperConfig
{
    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        var mapper = config.CreateMapper();
        services.AddSingleton(mapper);
    }

}