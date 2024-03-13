namespace MovieFlow.Modules.Movies.Core.Movies.Exceptions.Photos;

internal class PhotoNotFoundException(Guid photoId) : MovieFlowException($"Photo with id '{photoId}' not found");