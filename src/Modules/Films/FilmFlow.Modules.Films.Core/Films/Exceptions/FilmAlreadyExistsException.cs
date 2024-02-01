using FilmFlow.Shared.Abstractions.Exceptions;

namespace FilmFlow.Modules.Films.Application.Films.Commands.Create;

internal class FilmAlreadyExistsException(string message)
    : FilmFlowException($"Film with title '{message}' already exists.");
