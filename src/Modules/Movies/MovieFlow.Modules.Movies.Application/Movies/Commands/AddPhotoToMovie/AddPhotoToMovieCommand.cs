namespace MovieFlow.Modules.Movies.Application.Movies.Commands.AddPhotoToMovie;

internal record AddPhotoToMovieCommand(IFormFile Photo) : IRequest
{
    internal Guid MovieId;
}
