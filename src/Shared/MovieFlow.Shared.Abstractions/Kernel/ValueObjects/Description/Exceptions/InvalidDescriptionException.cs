using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Description.Exceptions;

public class InvalidDescriptionException(string value)
    : MovieFlowException($"Description: {value} is invalid.");