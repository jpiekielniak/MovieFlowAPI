using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Email.Exceptions;

internal class InvalidEmailException(string message) 
    : MovieFlowException($"Email: '{message}' is invalid.");