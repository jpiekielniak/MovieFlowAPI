namespace MovieFlow.Modules.Movies.Application.Movies.Commands.Create;

internal record CreateMovieCommand(
    string Title,
    string Description,
    int ReleaseYear,
    Guid DirectorId,
    List<GenreDto> Genres) : IRequest<CreateMovieResponse>;

internal record GenreDto(Guid Id);