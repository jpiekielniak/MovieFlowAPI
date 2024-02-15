namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.AddReview;

internal record AddReviewCommand(
    string Title,
    string Content,
    double Rating) : IRequest<AddReviewResponse>
{
    internal Guid MovieId { get; init; }
}