using Microsoft.EntityFrameworkCore;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Services;

internal sealed class MovieService : IMovieService
{
    public async Task<IQueryable<MovieReadModel>> FilterByTitleAsync(IQueryable<MovieReadModel> movies, string title,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(title))
            return await Task.FromResult(movies);

        var search = $"%{title}%";
        movies = movies.Where(
            f => Microsoft.EntityFrameworkCore.EF.Functions.ILike(
                f.Title, search));

        return await Task.FromResult(movies);
    }

    public async Task<IQueryable<MovieReadModel>> FilterByGenreAsync(IQueryable<MovieReadModel> movies, string genre,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(genre))
            return await Task.FromResult(movies);

        var search = $"%{genre}%";
        movies = movies.Where(
            f => f.Genres.Any(g => Microsoft.EntityFrameworkCore.EF.Functions.ILike(
                g.Name, search)));

        return await Task.FromResult(movies);
    }

    public async Task<IQueryable<MovieReadModel>> FilterByReleaseYearAsync(IQueryable<MovieReadModel> movies, int releaseYear, CancellationToken cancellationToken)
    {
        if (releaseYear <= 0)
            return await Task.FromResult(movies);

        movies = movies.Where(f => f.ReleaseYear == releaseYear);

        return await Task.FromResult(movies);
    }
}