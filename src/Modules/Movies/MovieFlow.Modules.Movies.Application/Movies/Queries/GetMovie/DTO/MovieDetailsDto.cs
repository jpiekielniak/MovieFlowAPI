using MovieFlow.Modules.Movies.Application.Movies.Queries.BrowseMovies.DTO;
using MovieFlow.Modules.Movies.Application.Shared.DTO;

namespace MovieFlow.Modules.Movies.Application.Movies.Queries.GetMovie.DTO;

internal record MovieDetailsDto(
    Guid Id,
    string Title,
    double Rating,
    int ReleaseYear,
    string Description,
    List<GenreNameDto> Genres,
    DirectorDto Director,
    List<ActorDto> Actors,
    List<string> Photos);