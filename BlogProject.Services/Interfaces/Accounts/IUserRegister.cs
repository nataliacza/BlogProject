using BlogProject.Dtos.Accounts;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;


namespace BlogProject.Services.Interfaces.Accounts;

public interface IUserRegister
{
    Task<IdentityUser?> Register(UserRegistrationDto userDetails);
}
