using BlogProject.Dtos.Accounts;


namespace BlogProject.Services.Interfaces.Accounts;

public interface IUserLogin
{
    Task<string?> Login(UserLoginDto userDetails);
}
