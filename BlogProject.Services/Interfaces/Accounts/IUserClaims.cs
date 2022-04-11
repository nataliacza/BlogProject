using BlogProject.Dtos.Accounts;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


namespace BlogProject.Services.Interfaces.Accounts;

public interface IUserClaims
{
    List<Claim> UserClaims(IdentityUser user);
}
