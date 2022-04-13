using BlogProject.Database.Models;
using System.Security.Claims;


namespace BlogProject.Services.Interfaces.Accounts;

public interface IUserClaims
{
    List<Claim> UserClaims(ApplicationUser user);
}
