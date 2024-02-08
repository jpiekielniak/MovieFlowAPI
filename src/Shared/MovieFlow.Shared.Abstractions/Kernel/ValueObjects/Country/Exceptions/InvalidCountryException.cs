using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Country.Exceptions;

public class InvalidCountryException(string message) 
    : MovieFlowException($"Country with value: {message} is invalid.");