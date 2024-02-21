using MovieFlow.Modules.Movies.Application.Movies.Commands.CreateMovie.DTO;

namespace MovieFlow.Modules.Movies.Application.Movies.Commands.CreateMovie;

internal record CreateMovieCommand(
    string Title,
    string Description,
    int ReleaseYear,
    Guid DirectorId,
    List<GenreDto> Genres) : IRequest<CreateMovieResponse>;