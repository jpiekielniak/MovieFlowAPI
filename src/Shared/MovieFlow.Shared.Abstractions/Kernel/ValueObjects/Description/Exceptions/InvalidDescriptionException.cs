using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Description.Exceptions;

internal class InvalidDescriptionException(string value)
    : MovieFlowException($"Description: {value} is invalid.");