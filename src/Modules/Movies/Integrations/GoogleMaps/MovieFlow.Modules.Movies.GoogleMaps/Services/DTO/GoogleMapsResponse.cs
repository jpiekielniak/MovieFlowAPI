namespace MovieFlow.Modules.Movies.GoogleMaps.Services.DTO;

internal record GoogleMapsResponse<T>(T Result);
internal record GoogleMapsResponse(List<CinemaDto> Results);
