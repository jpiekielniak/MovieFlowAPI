using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Title.Exceptions;

internal class InvalidTitleException(string value) 
    : MovieFlowException($"Title: {value} is invalid.");