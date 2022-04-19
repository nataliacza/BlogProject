using BlogProject.Database.Models;
using BlogProject.Dtos.Accounts;


namespace BlogProject.Services.Interfaces.Accounts;

public interface IUserRegister
{
    Task<ApplicationUser?> Register(UserRegistrationDto userDetails);
}
