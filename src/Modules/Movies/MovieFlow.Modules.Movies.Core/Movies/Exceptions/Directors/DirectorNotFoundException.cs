using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Movies.Core.Movies.Exceptions.Directors;

internal class DirectorNotFoundException(Guid directorId)
    : MovieFlowException($"Director with id {directorId} was not found.");