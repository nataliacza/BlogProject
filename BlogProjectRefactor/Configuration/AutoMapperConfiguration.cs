using AutoMapper;
using BlogProjectRefactor.Configuration.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;


namespace BlogProjectRefactor.Configuration;

public static class AutomapperConfiguration
{
    public static void AddAutomapper(this IServiceCollection services)
    {
        var mappingConfiguration = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new PostProfile());
        });

        IMapper mapper = mappingConfiguration.CreateMapper();
        services.AddSingleton(mapper);
    }
}
