using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Name.Exceptions;

public sealed class InvalidNameException(string message) 
    : MovieFlowException($"Invalid name: {message}");