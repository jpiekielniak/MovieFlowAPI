namespace MovieFlow.Modules.Movies.AzureStorage.Configuration;

internal sealed class AzureStorageConfiguration(IConfiguration configuration) : IAzureStorageConfiguration
{
    private const string SectionName = "azureStorage";
    private readonly IConfiguration _configuration = configuration.GetSection(SectionName);
    
    public string ConnectionString => _configuration.GetValue<string>(nameof(ConnectionString));
    public string ContainerName => _configuration.GetValue<string>(nameof(ContainerName));
}