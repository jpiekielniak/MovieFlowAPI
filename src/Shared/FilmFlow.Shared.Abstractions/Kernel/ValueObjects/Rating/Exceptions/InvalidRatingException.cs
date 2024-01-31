using FilmFlow.Shared.Abstractions.Exceptions;

namespace FilmFlow.Shared.Abstractions.Kernel.ValueObjects.Rating.Exceptions;

public class InvalidRatingException(double value) 
    : FilmFlowException($"Rating: {value} is invalid.");