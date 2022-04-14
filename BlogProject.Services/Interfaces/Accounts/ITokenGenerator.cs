using Microsoft.AspNetCore.Identity;


namespace BlogProject.Services.Interfaces.Accounts;

public interface ITokenGenerator
{
    public string GenerateJwtToken(IdentityUser user);
}
