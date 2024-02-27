namespace MovieFlow.Modules.Movies.Application.Genres.Commands.DeleteGenre;

internal record DeleteGenreCommand(Guid GenreId) : IRequest;