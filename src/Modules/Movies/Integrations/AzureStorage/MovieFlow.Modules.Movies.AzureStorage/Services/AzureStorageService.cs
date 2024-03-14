using MovieFlow.Modules.Movies.AzureStorage.Configuration;
using MovieFlow.Modules.Movies.AzureStorage.Services.Exceptions;

namespace MovieFlow.Modules.Movies.AzureStorage.Services;

internal class AzureStorageService(IAzureStorageConfiguration azureStorageConfiguration)
    : IAzureStorageService
{
    private readonly string _connectionString = azureStorageConfiguration.ConnectionString;
    private readonly string _containerName = azureStorageConfiguration.ContainerName;

    public async Task UploadImageAsync(IFormFile file)
    {
        var account = CloudStorageAccount.Parse(_connectionString);
        var client = account.CreateCloudBlobClient();
        var container = client.GetContainerReference(_containerName);
        var photo = container.GetBlockBlobReference(Path.GetFileName(file.FileName));
        await using var stream = file.OpenReadStream();
        await photo.UploadFromStreamAsync(stream);
    }

    public async Task<string> GetImageUrlAsync(string fileName)
    {
        var account = CloudStorageAccount.Parse(_connectionString);
        var client = account.CreateCloudBlobClient();
        var container = client.GetContainerReference(_containerName);
        var blob = container.GetBlockBlobReference(fileName);

        if (!await blob.ExistsAsync())
            throw new AzureFileNotFoundException("File not found");

        var imageUrl = blob.Uri.ToString();
        return imageUrl;
    }

    public async Task DeleteImageAsync(string fileName)
    {
        var account = CloudStorageAccount.Parse(_connectionString);
        var client = account.CreateCloudBlobClient();
        var container = client.GetContainerReference(_containerName);
        var blob = container.GetBlockBlobReference(fileName);

        if (!await blob.ExistsAsync())
            throw new AzureFileNotFoundException("File not found");
        
        await blob.DeleteIfExistsAsync();
    }
}