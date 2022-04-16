using BlogProject.Services.Interfaces.Uploads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Web.Controllers;

[Route("api/uploads")]
public class UploadsContoller : ControllerBase
{
    public readonly IStorageService _storageService;

    public UploadsContoller(IStorageService storageService)
    {
        _storageService = storageService;
    }

    [HttpPost]
    public IActionResult Upload(IFormFile file)
    {
        _storageService.Upload(file);

        return Ok();
    }
}
