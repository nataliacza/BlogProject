using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace BlogProject.Services.Accounts;

public class JwtToken 
{
    private readonly IConfiguration _configuration;

    public JwtToken(
        IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public JwtSecurityToken GetToken(List<Claim> authClaims)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey,
                                                        SecurityAlgorithms.HmacSha256);

        var header = new JwtHeader(signingCredentials);

        var playload = new JwtPayload(
            issuer: null,
            audience: null,
            claims: authClaims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddSeconds(double.Parse(_configuration["JWT:ExpirationTime"])),
            issuedAt: DateTime.UtcNow);

        var securityToken = new JwtSecurityToken(header, playload);

        return securityToken;
    }
}
