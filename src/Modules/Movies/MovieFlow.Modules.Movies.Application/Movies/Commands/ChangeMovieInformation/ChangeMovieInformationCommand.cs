namespace MovieFlow.Modules.Movies.Application.Movies.Commands.ChangeMovieInformation;

internal record ChangeMovieInformationCommand(
    string Title,
    double Rating,
    int ReleaseYear,
    string Description) : IRequest
{
    internal Guid MovieId { get; init; }
}