using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Movies.Core.Movies.Exceptions.Directors;

internal class DirectorNotFoundException(Guid message)
    : MovieFlowException($"Director with id {message} was not found.");