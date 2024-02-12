using Microsoft.Extensions.Logging;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using MovieFlow.Shared.Infrastructure;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.DataInitializer;

internal sealed class GenreInitializer(
    MoviesWriteDbContext writeDbContext,
    ILogger<Genre> logger) : IInitializer
{
    private readonly HashSet<string> _genres =
    [
        "Action", "Adventure", "Comedy", "Crime",
        "Drama", "Fantasy", "Historical", "Horror", "Mystery", "Romance",
        "Science Fiction", "Thriller", "Western"
    ];

    public async Task InitDataAsync()
    {
        if (!await writeDbContext.Genres.AnyAsync())
        {
            var genres = _genres.Select(Genre.Create).ToList();
            await writeDbContext.Genres.AddRangeAsync(genres);
            await writeDbContext.SaveChangesAsync();
            logger.Log(LogLevel.Information, "Genre data initialized");
        }
    }
}