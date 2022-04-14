using BlogProject.Services.Configuration;
using BlogProject.Services.Interfaces.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace BlogProject.Services.Accounts;

public class GenerateToken : ITokenGenerator
{
    private readonly JwtConfiguration _jwtSettings;

    public GenerateToken(
        IOptions<JwtConfiguration> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateJwtToken(IdentityUser user)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey,
                                                        SecurityAlgorithms.HmacSha256);

        var header = new JwtHeader(signingCredentials);

        var claims = GetJwtClaims(user);

        var currentDate = DateTime.UtcNow;

        var playload = new JwtPayload(
            issuer: null,
            audience: null,
            claims: claims,
            notBefore: currentDate,
            expires: currentDate.AddSeconds(_jwtSettings.ExpirationTime),
            issuedAt: currentDate);

        var securityToken = new JwtSecurityToken(header, playload);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    private List<Claim> GetJwtClaims(IdentityUser user)
    {
        var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()
                )
            };

        return claims;
    }
}
