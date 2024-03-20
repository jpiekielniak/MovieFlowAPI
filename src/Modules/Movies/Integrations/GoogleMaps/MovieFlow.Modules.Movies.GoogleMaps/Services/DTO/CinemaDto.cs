using Newtonsoft.Json;

namespace MovieFlow.Modules.Movies.GoogleMaps.Services.DTO;

public record CinemaDto
{
    [JsonProperty("place_id")]
    public string PlaceId { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public double Rating { get; set; }
    public string Vicinity { get; set; }
    public string Website { get; set; }
    public string PhotoUrl { get; set; }

}