namespace MovieFlow.Modules.Movies.Application.Genres.Commands.CreateGenre;

internal record CreateGenreCommand(string Name) : IRequest<CreateGenreResponse>;