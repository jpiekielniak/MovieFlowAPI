using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.FirstName.Exceptions;

internal sealed class InvalidFirstNameException(string message)
    : MovieFlowException($"First name with value: {message} is invalid.");
    