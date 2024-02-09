using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Password.Exceptions;

public class InvalidPasswordException(string message) 
    : MovieFlowException($"Invalid password: {message}");