using MovieFlow.Modules.Movies.Application.Movies.Queries.Browse;
using MovieFlow.Modules.Movies.Application.Movies.Queries.Browse.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Services;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Queries.BrowseMoviesHandler;

internal sealed class BrowseMoviesHandler(
    MoviesReadDbContext readDbContext,
    IMovieService movieService)
    : IRequestHandler<BrowseMoviesQuery, List<MovieDto>>
{
    public async Task<List<MovieDto>> Handle(BrowseMoviesQuery query,
        CancellationToken cancellationToken)
    {
        var movies = readDbContext
            .Movies
            .Include(x => x.Genres)
            .AsQueryable();

        movies = await movieService.FilterByTitleAsync(movies, query.Title, cancellationToken);
        movies = await movieService.FilterByGenreAsync(movies, query.Genre, cancellationToken);
        movies = await movieService.FilterByReleaseYearAsync(movies, query.ReleaseYear, cancellationToken);

        return await movies
            .AsNoTracking()
            .Select(x => x.AsMovieDto())
            .ToListAsync(cancellationToken);
    }
}