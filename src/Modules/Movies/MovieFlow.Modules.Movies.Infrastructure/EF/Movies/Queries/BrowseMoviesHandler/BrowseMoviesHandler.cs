using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieFlow.Modules.Movies.Application.Movies.Queries.Browse;
using MovieFlow.Modules.Movies.Application.Movies.Queries.Browse.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Queries.BrowseMoviesHandler;

internal sealed class BrowseMoviesHandler(
    MoviesReadDbContext readDbContext)
    : IRequestHandler<BrowseMoviesQuery, List<MovieDto>>
{
    public async Task<List<MovieDto>> Handle(BrowseMoviesQuery query,
        CancellationToken cancellationToken)
    {
        var movies = readDbContext
            .Movies
            .Include(x => x.Genres)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.Title))
        {
            var search = $"%{query.Title}%";
            movies = movies.Where(
                f => Microsoft.EntityFrameworkCore.EF.Functions.ILike(
                    f.Title, search));
        }

        if (query.ReleaseYear is > 0)
            movies = movies.Where(f => f.ReleaseYear == query.ReleaseYear);

        return await movies
            .AsNoTracking()
            .Select(x => x.AsMovieDto())
            .ToListAsync(cancellationToken);
    }
}