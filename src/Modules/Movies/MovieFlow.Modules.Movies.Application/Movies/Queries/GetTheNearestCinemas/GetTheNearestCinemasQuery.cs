using MovieFlow.Modules.Movies.GoogleMaps.Services.DTO;

namespace MovieFlow.Modules.Movies.Application.Movies.Queries.GetTheNearestCinemas;

internal record GetTheNearestCinemasQuery(double Latitude, double Longitude) : IRequest<List<CinemaDto>>;