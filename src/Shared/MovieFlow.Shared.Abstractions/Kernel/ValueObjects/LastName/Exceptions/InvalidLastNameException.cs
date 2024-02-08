using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.LastName.Exceptions;

internal sealed class InvalidLastNameException(string message)
    : MovieFlowException($"Last name with value: {message} is invalid.");
    