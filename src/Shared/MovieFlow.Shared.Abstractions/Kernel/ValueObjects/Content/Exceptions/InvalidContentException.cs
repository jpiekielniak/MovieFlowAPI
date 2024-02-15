using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Content.Exceptions;

public class InvalidContentException(string message) : MovieFlowException($"Invalid content: {message}");