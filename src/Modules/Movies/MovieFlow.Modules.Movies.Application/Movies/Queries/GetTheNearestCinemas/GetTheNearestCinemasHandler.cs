using MovieFlow.Modules.Movies.GoogleMaps.Services;
using MovieFlow.Modules.Movies.GoogleMaps.Services.DTO;

namespace MovieFlow.Modules.Movies.Application.Movies.Queries.GetTheNearestCinemas;

internal sealed class GetTheNearestCinemasHandler(IGoogleMapsService googleMapsService)
    : IRequestHandler<GetTheNearestCinemasQuery, List<CinemaDto>>
{
    public async Task<List<CinemaDto>> Handle(GetTheNearestCinemasQuery query, CancellationToken cancellationToken)
        => await googleMapsService.GetNearestCinemasAsync(query.Latitude, query.Longitude, cancellationToken);
}