using BlogProject.Dtos.Accounts;
using BlogProject.Services.Interfaces.Accounts;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BlogProject.Services.Accounts;

public class UserRegister : IUserRegister
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtToken _jwtToken;

    public UserRegister(
        UserManager<IdentityUser> userManager,
        JwtToken jwtToken)
    {
        _userManager = userManager;
        _jwtToken = jwtToken;
    }

    public Task<JwtSecurityToken?> Register(UserRegistrationDto userDetails)
    {
        throw new NotImplementedException();

        

    }
}

