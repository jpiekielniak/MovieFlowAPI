using Microsoft.Extensions.Configuration;

namespace MovieFlow.Modules.Movies.GoogleMaps.Configuration;

internal sealed class GoogleMapsConfiguration(IConfiguration configuration) : IGoogleMapsConfiguration
{
    private const string SectionName = "googleMaps";
    private readonly IConfiguration _configuration = configuration.GetSection(SectionName);
    
    public string ApiKey => _configuration.GetValue<string>(nameof(ApiKey));
}