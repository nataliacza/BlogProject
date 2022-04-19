using BlogProject.Database.Models;
using BlogProject.Services.Configuration;
using BlogProject.Services.Interfaces.Accounts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace BlogProject.Services.Accounts;

public class JwtTokenGenerator : ITokenGenerator
{
    private readonly JwtConfiguration _jwtSettings;

    public JwtTokenGenerator(
        IOptions<JwtConfiguration> jwtSettings
        )
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string GenerateJwtToken(ApplicationUser user)
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

    private List<Claim> GetJwtClaims(ApplicationUser user)
    {
        var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.GivenName , user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName , user.LastName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()
                )
            };

        return claims;
    }
}
