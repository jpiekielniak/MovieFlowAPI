namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.ChangeInformation;

internal record ChangeReviewInformationCommand(
    string Title,
    string Content,
    double Rating) : IRequest
{
    internal Guid MovieId { get; init; }
    internal Guid ReviewId { get; init; }
}