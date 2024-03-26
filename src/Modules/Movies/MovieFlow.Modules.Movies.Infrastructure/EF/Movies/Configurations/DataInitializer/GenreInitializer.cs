using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Name;
using MovieFlow.Shared.Infrastructure;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.DataInitializer;

internal class GenreInitializer(MoviesWriteDbContext writeDbContext) : IInitializer
{

    public async Task InitDataAsync()
    {
        if (!await writeDbContext.Genres.AnyAsync())
        {
            var genres = Genres.Select(Genre.Create).ToList();
            await writeDbContext.Genres.AddRangeAsync(genres);
            await writeDbContext.SaveChangesAsync();
        }
    }

    private static readonly HashSet<Name> Genres =
    [
        "Action", "Adventure", "Comedy", "Crime",
        "Drama", "Fantasy", "Historical", "Horror", "Mystery", "Romance",
        "Science Fiction", "Thriller", "Western"
    ];
}