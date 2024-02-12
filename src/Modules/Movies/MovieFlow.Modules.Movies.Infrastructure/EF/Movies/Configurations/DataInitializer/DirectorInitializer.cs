using Microsoft.Extensions.Logging;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;
using MovieFlow.Shared.Infrastructure;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.DataInitializer;

internal sealed class DirectorInitializer(
    MoviesWriteDbContext writeDbContext,
    ILogger<Director> logger) : IInitializer

{
    private const string FirstName = "John";
    private const string LastName = "Doe";
    private static readonly DateTime DateOfBirth = new(1980, 4, 20);
    private const string Country = "USA";

    public async Task InitDataAsync()
    {
        if (!await writeDbContext.Directors.AnyAsync())
        {
            await writeDbContext.Directors.AddAsync(Director
                .Create(FirstName, LastName, DateOfBirth, Country));
            await writeDbContext.SaveChangesAsync();
            logger.Log(LogLevel.Information, "Director initialized");
        }
    }
}