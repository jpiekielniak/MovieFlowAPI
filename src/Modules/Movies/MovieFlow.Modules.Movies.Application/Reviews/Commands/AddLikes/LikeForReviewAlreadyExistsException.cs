using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.AddLikes;

internal class LikeForReviewAlreadyExistsException(Guid userId)
    : MovieFlowException($"Like for review already exists for user with id: {userId}");