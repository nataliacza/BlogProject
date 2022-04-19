using BlogProject.Database.Models;
using BlogProject.Services.Interfaces.Accounts;
using Microsoft.AspNetCore.Http;


namespace BlogProject.Services.Accounts;

public class UserGetter : IContextUserGetter
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserGetter(
        IHttpContextAccessor httpContextAccessor
        )
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string GetUserId()
    {
        return _httpContextAccessor.HttpContext.User.Claims
            .FirstOrDefault(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
    }
}
