using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Movies.Core.Movies.Exceptions;

internal class MovieDoesNotExistException(Guid movieId)
    : MovieFlowException($"Movie with id {movieId} does not exist.");