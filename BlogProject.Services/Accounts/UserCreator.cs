using BlogProject.Database.Models;
using BlogProject.Dtos.Accounts;
using BlogProject.Services.Interfaces.Accounts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace BlogProject.Services.Accounts;

public class UserCreator : IUserRegister
{
    private readonly UserManager<ApplicationUser> _userManager;
    
    public UserCreator(
        UserManager<ApplicationUser> userManager
        )
    {
        _userManager = userManager;
    }

    public async Task<ApplicationUser?> Register(UserRegistrationDto userDetails)
{
        var userExists = await _userManager.Users.AnyAsync(x => x.UserName == userDetails.Username);

        if (userExists)
        {
            return null;
        }

        ApplicationUser user = new()
        {
            Id = Guid.NewGuid().ToString(),
            Email = userDetails.Email,
            UserName = userDetails.Username,
            FirstName = userDetails.FirstName,
            LastName = userDetails.LastName,
        };

        var result = await _userManager.CreateAsync(user, userDetails.Password);

        if (!result.Succeeded)
        {
            return null;
        }
        
        return user;
    }
}
