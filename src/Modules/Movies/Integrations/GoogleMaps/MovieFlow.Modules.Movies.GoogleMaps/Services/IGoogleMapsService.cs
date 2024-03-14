using MovieFlow.Modules.Movies.GoogleMaps.Services.DTO;

namespace MovieFlow.Modules.Movies.GoogleMaps.Services;

public interface IGoogleMapsService
{
    Task<List<CinemaDto>> GetNearestCinemasAsync(double latitude, double longitude, CancellationToken cancellationToken = default);
}