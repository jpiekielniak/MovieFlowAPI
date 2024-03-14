namespace MovieFlow.Modules.Movies.AzureStorage.Configuration;

public interface IAzureStorageConfiguration
{
    string ConnectionString { get; }
    string ContainerName { get; }
}