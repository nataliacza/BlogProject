using BlogProject.Dtos.Accounts;
using System.IdentityModel.Tokens.Jwt;


namespace BlogProject.Services.Interfaces.Accounts;

public interface IUserLogin
{
    Task<string?> Login(UserLoginDto userDetails);
}
