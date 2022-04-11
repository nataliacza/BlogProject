using BlogProject.Dtos.Accounts;
using BlogProject.Services.Interfaces.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BlogProject.Services.Accounts;

public class UserRegister : IUserRegister
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IUserClaims _userClaims;
    private readonly ITokenGenerator _jwtToken;

    public UserRegister(
        UserManager<IdentityUser> userManager,
        IUserClaims userClaims,
        ITokenGenerator jwtToken)
    {
        _userManager = userManager;
        _userClaims = userClaims;
        _jwtToken = jwtToken;
    }

    public async Task<IdentityUser?> Register(UserRegistrationDto userDetails)
{
        var userExists = await _userManager.Users.AnyAsync(x => x.UserName == userDetails.Username);

        if (userExists)
        {
            return null;
        }

        IdentityUser user = new()
        {
            Id = Guid.NewGuid().ToString(),
            Email = userDetails.Email,
            UserName = userDetails.Username
        };

        var result = await _userManager.CreateAsync(user, userDetails.Password);

        if (!result.Succeeded)
        {
            return null;
        }
        
        return user;
    }
}
