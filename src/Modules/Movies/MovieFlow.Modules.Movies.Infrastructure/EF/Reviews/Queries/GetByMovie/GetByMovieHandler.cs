using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetByMovie;
using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetByMovie.DTO;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using MovieFlow.Shared.Abstractions;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Reviews.Queries.GetByMovie;

internal sealed class GetByMovieHandler(
    MoviesReadDbContext readDbContext) : IRequestHandler<GetByMovieQuery, List<ReviewDto>>
{
    public async Task<List<ReviewDto>> Handle(GetByMovieQuery query,
        CancellationToken cancellationToken)
    {
        await readDbContext.Movies
            .SingleOrDefaultAsync(x => x.Id == query.movieId, cancellationToken)
            .NotNull(() => new MovieNotFoundException(query.movieId));

        return await readDbContext.Reviews
            .AsNoTracking()
            .Include(x => x.Likes)
            .Where(x => x.Movie.Id == query.movieId)
            .Select(x => x.AsDto())
            .ToListAsync(cancellationToken);
    }
}