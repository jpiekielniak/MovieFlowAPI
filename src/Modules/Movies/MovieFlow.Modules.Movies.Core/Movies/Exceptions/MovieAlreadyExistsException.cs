using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Movies.Core.Movies.Exceptions;

internal class MovieAlreadyExistsException(string message)
    : MovieFlowException($"Movie with title '{message}' already exists.");
