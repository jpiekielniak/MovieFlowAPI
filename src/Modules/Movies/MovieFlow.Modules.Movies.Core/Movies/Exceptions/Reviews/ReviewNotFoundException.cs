using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Movies.Core.Movies.Exceptions.Reviews;

internal class ReviewNotFoundException(Guid reviewId) 
    : MovieFlowException($"Review with id {reviewId} was not found.");