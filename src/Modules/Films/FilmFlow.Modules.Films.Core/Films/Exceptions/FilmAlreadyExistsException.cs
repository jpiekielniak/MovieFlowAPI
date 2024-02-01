using FilmFlow.Shared.Abstractions.Exceptions;

namespace FilmFlow.Modules.Films.Core.Films.Exceptions;

internal class FilmAlreadyExistsException(string message)
    : FilmFlowException($"Film with title '{message}' already exists.");
