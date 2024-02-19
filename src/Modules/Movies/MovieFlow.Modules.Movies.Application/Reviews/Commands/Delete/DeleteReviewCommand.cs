namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.Delete;

public record DeleteReviewCommand(
    Guid MovieId,
    Guid ReviewId) : IRequest;