using System.Globalization;
using MovieFlow.Modules.Movies.GoogleMaps.Configuration;
using MovieFlow.Modules.Movies.GoogleMaps.Services.DTO;
using Newtonsoft.Json;

namespace MovieFlow.Modules.Movies.GoogleMaps.Services;

internal class GoogleMapsService(IGoogleMapsConfiguration googleMapsConfiguration, HttpClient httpClient)
    : IGoogleMapsService
{
    private readonly string _apiKey = googleMapsConfiguration.ApiKey;
    private const ushort Radius = 25_000;
    private const string BaseUrl = "https://maps.googleapis.com/maps/api/place";

    public async Task<List<CinemaDto>> GetNearestCinemasAsync(double latitude, double longitude,
        CancellationToken cancellationToken = default)
    {
        var url = $"{BaseUrl}/nearbysearch/json?keyword=kino&" +
                  $"location={latitude.ToString(CultureInfo.InvariantCulture)}," +
                  $"{longitude.ToString(CultureInfo.InvariantCulture)}" +
                  $"&radius={Radius}&language=pl&key={_apiKey}";

        var response = await httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
        var cinemasResponse = JsonConvert.DeserializeObject<GoogleMapsResponse>(jsonString);

        var cinemas = cinemasResponse.Results
            .Take(5)
            .ToList();

        await Parallel.ForEachAsync(cinemas, cancellationToken, async (cinema, _) =>
        {
            var details = await GetCinemaDetailsAsync(cinema.PlaceId, cancellationToken);
            (cinema.Website, cinema.Url, cinema.PhotoUrl) = details;
        });
        
        return cinemas;
    }
    
    private async Task<(string Website, string Url, string photoUrl)> GetCinemaDetailsAsync(string placeId,
        CancellationToken cancellationToken)
    {
        var url = $"{BaseUrl}/details/json?place_id={placeId}&key={_apiKey}";
        var response = await httpClient.GetAsync(url, cancellationToken);
        response.EnsureSuccessStatusCode();

        var jsonString = await response.Content.ReadAsStringAsync(cancellationToken);
        var placeDetails = JsonConvert.DeserializeObject<GoogleMapsResponse<CinemaDetailsDto>>(jsonString);

        var photoUrl = placeDetails.Result.Photos?.FirstOrDefault()?.PhotoReference != null
            ? $"{BaseUrl}/photo?maxwidth=400&photoreference={placeDetails.Result.Photos.First().PhotoReference}&key={_apiKey}"
            : null;

        return (placeDetails.Result.Website, placeDetails.Result.Url, photoUrl);
    }
}