namespace MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;

internal class MovieAlreadyExistsException(string movieTitle)
    : MovieFlowException($"Movie with title '{movieTitle}' already exists.");