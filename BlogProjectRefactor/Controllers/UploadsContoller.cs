using BlogProject.Services.Interfaces.Uploads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogProject.Web.Controllers;

[Route("api/uploads")]
public class UploadsContoller : ControllerBase
{
    private readonly IUploadFile _uploadFile;

    public UploadsContoller(
        IUploadFile uploadFile)
    {
        _uploadFile = uploadFile;
    }

    [HttpPost]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null)
        {
            return BadRequest("File not attached.");
        }

        long fileMaxSize = 1000000;

        if (file.Length > fileMaxSize)
        {
            return BadRequest($"Upload file max to {fileMaxSize} bytes.");
        }

        var fileDto = await _uploadFile.Upload(file);
        
        return Ok(fileDto);
    }
}
