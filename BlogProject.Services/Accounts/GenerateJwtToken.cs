using BlogProject.Database.Models;
using BlogProject.Services.Configuration;
using BlogProject.Services.Interfaces.Accounts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace BlogProject.Services.Accounts;

public class GenerateJwtToken : ITokenGenerator, IUserClaims
{
    private readonly JwtConfiguration _jwtSettings;

    public GenerateJwtToken(
        IOptions<JwtConfiguration> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public List<Claim> UserClaims(ApplicationUser user)
    {
        var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.GivenName , user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName , user.LastName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()
                )
            };

        return authClaims;
    }


    public string GenerateToken(List<Claim> authClaims)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey,
                                                        SecurityAlgorithms.HmacSha256);

        var header = new JwtHeader(signingCredentials);

        var playload = new JwtPayload(
            issuer: null,
            audience: null,
            claims: authClaims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddSeconds(_jwtSettings.ExpirationTime),
            issuedAt: DateTime.UtcNow);

        var securityToken = new JwtSecurityToken(header, playload);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
