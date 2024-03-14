using System.Globalization;
using MovieFlow.Modules.Movies.GoogleMaps.Configuration;
using MovieFlow.Modules.Movies.GoogleMaps.Services.DTO;
using Newtonsoft.Json;

namespace MovieFlow.Modules.Movies.GoogleMaps.Services;

internal class GoogleMapsService(IGoogleMapsConfiguration googleMapsConfiguration) : IGoogleMapsService
{
    private readonly string _apiKey = googleMapsConfiguration.ApiKey;
    private const ushort Radius = 25_000;

    public async Task<List<CinemaDto>> GetNearestCinemasAsync(double latitude, double longitude,
        CancellationToken cancellationToken = default)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(
            $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?keyword=kino&" +
            $"location={latitude.ToString(CultureInfo.CurrentCulture).Replace(",", ".")}," +
            $"{longitude.ToString(CultureInfo.InvariantCulture)}" +
            $"&radius={Radius}&language=pl&key={_apiKey}",
            cancellationToken);

        var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
        var cinemasResponse = JsonConvert.DeserializeObject<GoogleMapsResponse>(jsonString);

        var cinemas = cinemasResponse.Results.Take(5).ToList();

        foreach (var cinema in cinemas)
        {
            (cinema.Website, cinema.Url) = await GetCinemaDetailsAsync(cinema.Place_Id, cancellationToken);
        }

        return cinemas;
    }

    private async Task<(string Website, string Url)> GetCinemaDetailsAsync(string placeId,
        CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(
            $"https://maps.googleapis.com/maps/api/place/details/json?place_id={placeId}&key={_apiKey}",
            cancellationToken);
        var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
        var placeDetails = JsonConvert.DeserializeObject<GoogleMapsPlaceDetailsResponse>(jsonString);

        return (placeDetails.Result.Website, placeDetails.Result.Url);
    }
}

internal class GoogleMapsResponse
{
    public List<CinemaDto> Results { get; set; }
}

internal class GoogleMapsPlaceDetailsResponse
{
    public CinemaDetails Result { get; set; }
}

internal class CinemaDetails
{
    public string Website { get; set; }
    public string Url { get; set; }
}