using BlogProject.Dtos.Accounts;
using BlogProject.Services.Interfaces.Accounts;
using Microsoft.AspNetCore.Identity;


namespace BlogProject.Services.Accounts;

public class UserLogin : IUserLogin
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenGenerator _jwtToken;

    public UserLogin(
        UserManager<IdentityUser> userManager,
        ITokenGenerator jwtToken)
    {
        _userManager = userManager;
        _jwtToken = jwtToken;
    }

    public async Task<string?> Login(UserLoginDto userDetails)
    {
        var user = await _userManager.FindByNameAsync(userDetails.Username);

        var checkPW = await _userManager.CheckPasswordAsync(user, userDetails.Password);

        if (user == null || !checkPW)
        {
            return null;
        }

        var token = _jwtToken.GenerateJwtToken(user);

        return token;
    }
}
