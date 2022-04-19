using BlogProject.Dtos.Accounts;
using BlogProject.Services.Interfaces.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BlogProject.Services.Accounts;

public class UserRegister : IUserRegister
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserRegister(
        UserManager<IdentityUser> userManager
        )
    {
        _userManager = userManager;
    }

    public async Task<IdentityUser?> Register(UserRegistrationDto userDetails)
{
        var userExists = await _userManager.Users.AnyAsync(x => x.UserName == userDetails.Username);

        if (userExists)
        {
            return null;
        }

        IdentityUser user = new()
        {
            Id = Guid.NewGuid().ToString(),
            Email = userDetails.Email,
            UserName = userDetails.Username
        };

        var result = await _userManager.CreateAsync(user, userDetails.Password);

        if (!result.Succeeded)
        {
            return null;
        }
        
        return user;
    }
}
