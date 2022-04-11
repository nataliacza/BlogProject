using System.Security.Claims;


namespace BlogProject.Services.Interfaces.Accounts;

public interface ITokenGenerator
{
    public string GenerateToken(List<Claim> authClaims);
}
