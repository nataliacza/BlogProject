using Microsoft.Extensions.DependencyInjection;
using BlogProject.Services.Posts;
using BlogProject.Services.Accounts;
using BlogProject.Services.Uploads;
using BlogProject.Services.Interfaces.Posts;
using BlogProject.Services.Interfaces.Accounts;
using BlogProject.Services.Interfaces.Uploads;

namespace BlogProject.Web.Configuration;

public static class ServicesConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IPostGetter, EfPostGetter>();
        services.AddScoped<IPostAdder, EfPostAdder>();
        services.AddScoped<IPostRemover, EfPostRemover>();
        services.AddScoped<IPostUpdater, EfPostUpdater>();

        services.AddScoped<IUserLogin, UserLogin>();
        services.AddScoped<IUserRegister, UserRegister>();

        services.AddScoped<ITokenGenerator, GenerateJwtToken>();
        services.AddScoped<IUserClaims, GenerateJwtToken>();

        services.AddScoped<IStorageService, StorageService>();
    }
}
