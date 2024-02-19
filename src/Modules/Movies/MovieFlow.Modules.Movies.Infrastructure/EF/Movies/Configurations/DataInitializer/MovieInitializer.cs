using Microsoft.Extensions.Logging;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using MovieFlow.Shared.Infrastructure;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.DataInitializer;

internal sealed class MovieInitializer(
    MoviesWriteDbContext writeDbContext,
    ILogger<Movie> logger) : IInitializer
{
    private const string Title = "The Shawshank Redemption";
    private const string Description = "Two imprisoned...";
    private const int ReleaseYear = 1994;

    public async Task InitDataAsync()
    {
        if (!await writeDbContext.Movies.AnyAsync())
        {
            var genre = await writeDbContext.Genres.Take(2).ToListAsync();
            var director = await writeDbContext.Directors.FirstAsync();

            await writeDbContext.Movies.AddAsync(Movie.Create(
                Title, Description, ReleaseYear, director, genre)
            );
            await writeDbContext.SaveChangesAsync();
            logger.Log(LogLevel.Information, "Movie initialized");
        }
    }
}