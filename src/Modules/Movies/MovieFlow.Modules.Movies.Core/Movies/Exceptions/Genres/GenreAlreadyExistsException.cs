using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Movies.Core.Movies.Exceptions.Genres;

internal class GenreAlreadyExistsException(string genre)
    : MovieFlowException($"Genre with name '{genre}' already exists.");