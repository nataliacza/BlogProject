using BlogProject.Dtos.Uploads;
using BlogProject.Services.Interfaces.Uploads;
using Microsoft.AspNetCore.Http;


namespace BlogProject.Services.Uploads;

public class UploadFile : IUploadFile
{
    public readonly IStorageService _storageService;

    public UploadFile(
        IStorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task<FileDetailsDto?> Upload(IFormFile formFile)
    {
        if (formFile == null)
        {
            return null;
        }

        return await _storageService.UploadToBlobStorage(formFile); ;
    }
}
