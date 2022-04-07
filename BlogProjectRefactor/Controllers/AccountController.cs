using BlogProject.Dtos.Accounts;
using BlogProject.Services.Interfaces.Accounts;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;


[Route("api/accounts")]
public class AccountController : ControllerBase
{
    private readonly IUserLogin _userLogin;
    private readonly IUserRegister _userRegister;

    public AccountController(
        IUserLogin userLogin,
        IUserRegister userRegister
        )
    {
        _userLogin = userLogin;
        _userRegister = userRegister;
    }


    /// <summary>
    /// User login endpoint
    /// </summary>
    /// <param name="userModel"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginDto userDetails)
    {
        var response = await _userLogin.Login(userDetails);

        if (response == null)
        {
            return BadRequest($"Invalid username or PW");
        }

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(response),
            expiration = response.ValidTo
        });
    }


    /// <summary>
    /// User registration endpoint
    /// </summary>
    /// <param name="userDetails"></param>
    /// <returns></returns>
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationDto userDetails)
    {

        var response = await _userRegister.Register(userDetails);

        if (response == null)
        {
            return BadRequest("Error!");
        }

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(response),
            expiration = response.ValidTo
        });
    }
}
