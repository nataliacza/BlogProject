using Microsoft.AspNetCore.Http;

namespace BlogProject.Services.Interfaces.Uploads;

public interface IStorageService
{
    void Upload(IFormFile formFile);
}
