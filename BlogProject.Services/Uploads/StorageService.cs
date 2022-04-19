using Azure.Storage.Blobs;
using BlogProject.Dtos.Uploads;
using BlogProject.Services.Configuration;
using BlogProject.Services.Interfaces.Uploads;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace BlogProject.Services.Uploads;

public class StorageService : IStorageService
{
    private readonly BlobServiceClient _blobServiceClient;
    private readonly AzureStorageConfiguration _blobSettings;

    public StorageService(
        BlobServiceClient blobServiceClient,
        IOptions<AzureStorageConfiguration> blobSettings
        )
    {
        _blobServiceClient = blobServiceClient;
        _blobSettings = blobSettings.Value;
    }

    public async Task<FileDetailsDto?> UploadToBlobStorage(IFormFile formFile)
    {
        var containerName = _blobSettings.ContainerName;
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);

        var fileInfo = new FileInfo(formFile.FileName);
        string newFileName = Guid.NewGuid().ToString() + fileInfo.Extension;

        var blobClient = containerClient.GetBlobClient(newFileName);

        using var fileStream = formFile.OpenReadStream();

        await blobClient.UploadAsync(fileStream, true);

        FileDetailsDto fileDto = new FileDetailsDto
        {
            FileName = blobClient.Name,
            FileUri = blobClient.Uri.ToString()
        };

        return fileDto;
    }
}
