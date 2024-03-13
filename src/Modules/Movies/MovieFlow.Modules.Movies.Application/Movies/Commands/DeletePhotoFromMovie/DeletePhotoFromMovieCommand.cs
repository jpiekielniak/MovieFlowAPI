namespace MovieFlow.Modules.Movies.Application.Movies.Commands.DeletePhotoFromMovie;

internal record DeletePhotoFromMovieCommand(Guid PhotoId) : IRequest
{
    internal Guid MovieId { get; init; }
}