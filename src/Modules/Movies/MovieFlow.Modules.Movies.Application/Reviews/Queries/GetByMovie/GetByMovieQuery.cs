using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetByMovie.DTO;

namespace MovieFlow.Modules.Movies.Application.Reviews.Queries.GetByMovie;

internal record GetByMovieQuery(Guid movieId) : IRequest<List<ReviewDto>>;