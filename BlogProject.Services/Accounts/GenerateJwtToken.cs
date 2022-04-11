using BlogProject.Dtos.Accounts;
using BlogProject.Services.Configuration;
using BlogProject.Services.Interfaces.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


// TO DO
// interface do jwt token generator - change name
// add authClaims - add separate method
// IOptions - configuration


namespace BlogProject.Services.Accounts;

public class GenerateJwtToken : ITokenGenerator, IUserClaims
{
    //private readonly IConfiguration _configuration;
    private readonly JwtConfiguration _jwtSettings;

    public GenerateJwtToken(
        IOptions<JwtConfiguration> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public List<Claim> UserClaims(IdentityUser user)
    {
        var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id),
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
            expires: DateTime.UtcNow.AddSeconds(double.Parse(_jwtSettings.ExpirationTime.ToString())),
            issuedAt: DateTime.UtcNow);

        var securityToken = new JwtSecurityToken(header, playload);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
