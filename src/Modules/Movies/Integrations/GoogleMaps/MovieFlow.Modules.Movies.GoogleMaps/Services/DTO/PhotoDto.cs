using Newtonsoft.Json;

namespace MovieFlow.Modules.Movies.GoogleMaps.Services.DTO;

internal record PhotoDto
{
    [JsonProperty("photo_reference")]
    public string PhotoReference { get; set; }
}