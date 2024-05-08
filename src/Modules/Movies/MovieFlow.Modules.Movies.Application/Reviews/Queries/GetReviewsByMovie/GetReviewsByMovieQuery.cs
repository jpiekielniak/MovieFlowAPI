using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsByMovie.DTO;

namespace MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsByMovie;

internal record GetReviewsByMovieQuery(Guid MovieId) : IRequest<List<ReviewDto>>;