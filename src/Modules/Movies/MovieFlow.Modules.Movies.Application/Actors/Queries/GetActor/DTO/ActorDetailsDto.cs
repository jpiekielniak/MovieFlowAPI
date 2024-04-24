using MovieFlow.Modules.Movies.Application.Movies.Queries.BrowseMovies.DTO;

namespace MovieFlow.Modules.Movies.Application.Actors.Queries.GetActor.DTO;

internal record ActorDetailsDto(
    Guid ActorId,
    string FirstName,
    string LastName,
    int Age,
    string Country,
    string PhotoUrl,
    IReadOnlyCollection<MovieDto> Movies);