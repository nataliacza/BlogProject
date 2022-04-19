using BlogProject.Database.Models;
using BlogProject.Dtos.Accounts;
using BlogProject.Services.Interfaces.Accounts;
using Microsoft.AspNetCore.Identity;


namespace BlogProject.Services.Accounts;

public class UserLogin : IUserLogin
{
<<<<<<< HEAD
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IUserClaims _userClaims;
    private readonly ITokenGenerator _jwtToken;

    public UserLogin(
        UserManager<ApplicationUser> userManager,
        IUserClaims userClaims,
=======
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenGenerator _jwtToken;

    public UserLogin(
        UserManager<IdentityUser> userManager,
>>>>>>> master
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
