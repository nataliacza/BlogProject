using BlogProject.Database.Models;


namespace BlogProject.Services.Interfaces.Accounts;

public interface ITokenGenerator
{
    public string GenerateJwtToken(ApplicationUser user);
}
