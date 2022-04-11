using BlogProject.Dtos.Accounts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogProject.Web.Controllers;

[Route("api/accounts/roles")]
public class AccountController : ControllerBase
{
    [HttpPost]
    [Route("add")]
    public async Task<IActionResult> AddRole([FromBody] UserRoleDto userRole)
    {
        return Ok();
    }
}
