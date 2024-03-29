namespace MovieFlow.Modules.Movies.AzureStorage.Services;

public interface IAzureStorageService
{
    Task UploadImageAsync(IFormFile file);
    Task<string> GetImageUrlAsync(string fileName);
    Task DeleteImageAsync(string fileName);
}