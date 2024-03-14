using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Movies.AzureStorage.Services.Exceptions;

internal class AzureFileNotFoundException(string message) : MovieFlowException(message);