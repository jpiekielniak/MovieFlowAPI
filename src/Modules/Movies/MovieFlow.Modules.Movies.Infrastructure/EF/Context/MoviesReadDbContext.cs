using Microsoft.EntityFrameworkCore;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Context;

internal sealed class MoviesReadDbContext(DbContextOptions<MoviesReadDbContext> options) 
    : DbContext(options)
{
    public DbSet<MovieReadModel> Movies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("movies");
        modelBuilder.ApplyConfiguration(new MovieReadConfiguration());
    }
}