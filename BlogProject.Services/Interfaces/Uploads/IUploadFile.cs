using BlogProject.Dtos.Uploads;
using Microsoft.AspNetCore.Http;

namespace BlogProject.Services.Interfaces.Uploads;

public interface IUploadFile
{
    Task<FileDetailsDto?> Upload(IFormFile formFile);
}
