namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.Add;

internal record AddReviewCommand(
    string Title,
    string Content,
    double Rating) : IRequest<AddReviewResponse>
{
    internal Guid MovieId { get; init; }
}