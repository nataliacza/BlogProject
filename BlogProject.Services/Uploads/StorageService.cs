using Azure.Storage.Blobs;
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
        IOptions<AzureStorageConfiguration> blobSettings)
    {
        _blobServiceClient = blobServiceClient;
        _blobSettings = blobSettings.Value;
    }

    public void Upload(IFormFile formFile)
    {
        var containerName = _blobSettings.ContainerName;
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        var blobClient = containerClient.GetBlobClient(formFile.FileName);

        using var stream = formFile.OpenReadStream();
        blobClient.Upload(stream, true);
    }
}
