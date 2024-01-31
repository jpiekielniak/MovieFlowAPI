using FilmFlow.Shared.Abstractions.Exceptions;

namespace FilmFlow.Shared.Abstractions.Kernel.ValueObjects.ReleaseYear;

internal class InvalidReleaseYearException(int value) 
    : FilmFlowException($"Release year: {value} is invalid.");
