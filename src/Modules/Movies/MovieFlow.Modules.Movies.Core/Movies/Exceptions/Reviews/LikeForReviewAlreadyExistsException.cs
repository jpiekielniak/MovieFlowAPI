namespace MovieFlow.Modules.Movies.Core.Movies.Exceptions.Reviews;

internal class LikeForReviewAlreadyExistsException(Guid userId)
    : MovieFlowException($"Like for review already exists for user with id: {userId}");