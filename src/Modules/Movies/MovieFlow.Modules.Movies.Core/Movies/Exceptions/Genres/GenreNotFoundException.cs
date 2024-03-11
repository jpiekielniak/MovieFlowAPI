namespace MovieFlow.Modules.Movies.Core.Movies.Exceptions.Genres;

internal class GenreNotFoundException(Guid genreId) 
    : MovieFlowException($"Genre with id: {genreId} was not found.");