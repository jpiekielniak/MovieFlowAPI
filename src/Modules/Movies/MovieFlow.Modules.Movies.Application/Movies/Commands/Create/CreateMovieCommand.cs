
namespace MovieFlow.Modules.Movies.Application.Movies.Commands.Create;

internal record CreateMovieCommand(
    string Title,
    string Description,
    double Rating,
    int ReleaseYear,
    Guid DirectorId,
    List<GenreDto> Genres) : IRequest<CreateMovieResponse>;

internal record GenreDto(Guid Id);