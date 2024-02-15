using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Context;

internal sealed class MoviesReadDbContext(DbContextOptions<MoviesReadDbContext> options)
    : DbContext(options)
{
    public DbSet<MovieReadModel> Movies { get; set; }
    public DbSet<GenreReadModel> Genres { get; set; }
    public DbSet<DirectorReadModel> Directors { get; set; }
    public DbSet<ReviewReadModel> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("movies");
        modelBuilder.ApplyConfiguration(new MovieReadConfiguration());
        modelBuilder.ApplyConfiguration(new GenreReadConfiguration());
        modelBuilder.ApplyConfiguration(new DirectorReadConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewReadConfiguration());
    }
}