using MovieFlow.Modules.Movies.Application.Directors.Queries.GetMoviesForDirector.DTO;

namespace MovieFlow.Modules.Movies.Application.Directors.Queries.GetMoviesForDirector;

internal record GetMoviesForDirectorQuery(Guid DirectorId) : IRequest<List<DirectorMovieDto>>;