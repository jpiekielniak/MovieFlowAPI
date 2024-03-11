namespace MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;

internal class MovieNotFoundException(Guid movieId)
    : MovieFlowException($"Movie with id {movieId} not found.");