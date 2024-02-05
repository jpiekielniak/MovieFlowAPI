using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Rating.Exceptions;

internal class InvalidRatingException(double value) 
    : MovieFlowException($"Rating: {value} is invalid.");