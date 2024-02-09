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
            .Include(x => x.Director)
            .AsQueryable();

        movies = movieService.FilterByTitle(movies, query.Title);
        movies = movieService.FilterByGenre(movies, query.Genre);
        movies = movieService.FilterByReleaseYear(movies, query.ReleaseYear);
        movies = movieService.FilterByDirector(movies, query.Director);

        return await movies
            .AsNoTracking()
            .Select(x => x.AsMovieDto())
            .ToListAsync(cancellationToken);
    }
}