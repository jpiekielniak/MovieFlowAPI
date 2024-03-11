namespace MovieFlow.Modules.Movies.Core.Movies.Exceptions.Reviews;

internal class ReviewDoesNotBelongToUserException(Guid reviewId)
    : MovieFlowException($"Review with id: '{reviewId}' does not belong to user.");