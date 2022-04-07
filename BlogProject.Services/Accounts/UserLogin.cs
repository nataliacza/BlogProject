using BlogProject.Dtos.Accounts;
using BlogProject.Services.Interfaces.Accounts;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace BlogProject.Services.Accounts;

public class UserLogin : IUserLogin
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly JwtToken _jwtToken;

    public UserLogin(
        UserManager<IdentityUser> userManager,
        JwtToken jwtToken)
    {
        _userManager = userManager;
        _jwtToken = jwtToken;
    }

    public async Task<JwtSecurityToken?> Login(UserLoginDto userDetails)
    {
        var user = await _userManager.FindByNameAsync(userDetails.Username);

        var checkPW = await _userManager.CheckPasswordAsync(user, userDetails.Password);

        if (user == null || !checkPW)
        {
            return null;
        }

        var authClaims = new List<Claim>
            {
                //new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

        var token = _jwtToken.GetToken(authClaims);

        return token;
    }
}
