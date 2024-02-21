namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.AddLikeToReview;

internal record AddLikeToReviewCommand(bool IsPositive) : IRequest
{
    internal Guid MovieId { get; init; }
    internal Guid ReviewId { get; init; }
}