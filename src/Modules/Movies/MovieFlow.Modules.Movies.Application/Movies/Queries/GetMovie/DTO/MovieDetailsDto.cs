using MovieFlow.Modules.Movies.Application.Shared.DTO;

namespace MovieFlow.Modules.Movies.Application.Movies.Queries.GetMovie.DTO;

internal record MovieDetailsDto(
    Guid Id,
    string Title,
    double Rating,
    int ReleaseYear,
    string Description,
    List<string> Genres,
    DirectorDto Director,
    List<string> MoviePhotos);