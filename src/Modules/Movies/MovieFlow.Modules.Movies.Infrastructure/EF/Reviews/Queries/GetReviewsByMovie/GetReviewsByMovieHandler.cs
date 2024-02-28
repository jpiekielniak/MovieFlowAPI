using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsByMovie;
using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsByMovie.DTO;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using MovieFlow.Shared.Abstractions;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Reviews.Queries.GetReviewsByMovie;

internal sealed class GetReviewsByMovieHandler(MoviesReadDbContext readDbContext)
    : IRequestHandler<GetReviewsByMovieQuery, List<ReviewDto>>
{
    public async Task<List<ReviewDto>> Handle(GetReviewsByMovieQuery query,
        CancellationToken cancellationToken)
    {
        await readDbContext.Movies
            .SingleOrDefaultAsync(x => x.Id == query.movieId, cancellationToken)
            .NotNull(() => new MovieNotFoundException(query.movieId));

        var reviews = await readDbContext.Reviews
            .AsNoTracking()
            .Include(x => x.Likes)
            .Where(x => x.Movie.Id == query.movieId)
            .Select(x => x.AsDto())
            .ToListAsync(cancellationToken);

        return reviews;
    }
}