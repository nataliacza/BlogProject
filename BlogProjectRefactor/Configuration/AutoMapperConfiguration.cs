using AutoMapper;
using BlogProject.Web.Configuration.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;


namespace BlogProject.Web.Configuration;

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
