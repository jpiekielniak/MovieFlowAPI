namespace MovieFlow.Modules.Movies.Application.Movies.Commands.DeleteMovie;

internal record DeleteMovieCommand(Guid MovieId) : IRequest;