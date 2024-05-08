namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.DeleteReview;

internal record DeleteReviewCommand(Guid MovieId, Guid ReviewId) : IRequest;