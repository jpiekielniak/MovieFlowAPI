using MovieFlow.Modules.Movies.Application.Movies.Queries.GetMovie.DTO;

namespace MovieFlow.Modules.Movies.Application.Movies.Queries.GetMovie;

internal record GetMovieQuery(Guid MovieId) : IRequest<MovieDetailsDto>;