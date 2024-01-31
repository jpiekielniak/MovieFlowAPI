using FilmFlow.Shared.Abstractions.Exceptions;

namespace FilmFlow.Shared.Abstractions.Kernel.ValueObjects.Title.Exceptions;

public class InvalidTitleException(string value) 
    : FilmFlowException($"Title: {value} is invalid.");