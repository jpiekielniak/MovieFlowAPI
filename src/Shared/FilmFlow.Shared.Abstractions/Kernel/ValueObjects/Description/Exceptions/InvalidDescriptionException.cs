using FilmFlow.Shared.Abstractions.Exceptions;

namespace FilmFlow.Shared.Abstractions.Kernel.ValueObjects.Description.Exceptions;

public class InvalidDescriptionException(string value)
    : FilmFlowException($"Description: {value} is invalid.");