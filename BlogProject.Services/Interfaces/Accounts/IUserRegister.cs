using BlogProject.Dtos.Accounts;
using System.IdentityModel.Tokens.Jwt;


namespace BlogProject.Services.Interfaces.Accounts;

public interface IUserRegister
{
    Task<JwtSecurityToken?> Register(UserRegistrationDto userDetails);
}
