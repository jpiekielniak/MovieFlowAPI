using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.ReleaseYear.Exceptions;

internal class InvalidReleaseYearException(int value) 
    : MovieFlowException($"Release year: {value} is invalid.");
