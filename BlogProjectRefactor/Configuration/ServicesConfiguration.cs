using Microsoft.Extensions.DependencyInjection;
using BlogProject.Services.Posts;
using BlogProject.Services.Interfaces.Posts;

namespace BlogProjectRefactor.Configuration
{
    public static class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPostGetter, EfPostGetter>();
            services.AddScoped<IPostAdder, EfPostAdder>();
            services.AddScoped<IPostRemover, EfPostRemover>();
            services.AddScoped<IPostUpdater, EfPostUpdater>();
        }
    }
}
