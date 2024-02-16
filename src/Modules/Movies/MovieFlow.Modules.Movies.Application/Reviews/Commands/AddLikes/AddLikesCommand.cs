namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.AddLikes;

internal record AddLikesCommand(bool IsPositive) : IRequest
{
    internal Guid MovieId { get; init; }
    internal Guid ReviewId { get; init; }
}