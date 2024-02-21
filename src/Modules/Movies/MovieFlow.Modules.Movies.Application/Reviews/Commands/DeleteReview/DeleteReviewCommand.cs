namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.DeleteReview;

public record DeleteReviewCommand(Guid MovieId, Guid ReviewId) : IRequest;