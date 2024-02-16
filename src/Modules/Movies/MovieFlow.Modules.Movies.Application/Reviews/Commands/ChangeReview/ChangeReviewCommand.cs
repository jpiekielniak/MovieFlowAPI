namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.ChangeReview;

internal record ChangeReviewCommand(
    string Title,
    string Content,
    double Rating) : IRequest
{
    internal Guid MovieId { get; init; }
    internal Guid ReviewId { get; init; }
}