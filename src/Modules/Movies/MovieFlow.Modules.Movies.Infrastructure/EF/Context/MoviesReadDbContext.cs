using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Context;

internal sealed class MoviesReadDbContext(DbContextOptions<MoviesReadDbContext> options)
    : DbContext(options)
{
    private static string Schema => "movies";
    public DbSet<MovieReadModel> Movies { get; set; }
    public DbSet<GenreReadModel> Genres { get; set; }
    public DbSet<DirectorReadModel> Directors { get; set; }
    public DbSet<ReviewReadModel> Reviews { get; set; }
    public DbSet<LikeReadModel> Likes { get; set; }
    public DbSet<PhotoReadModel> Photos { get; set; }
    public DbSet<MoviePhotoReadModel> MoviePhotos {get; set;}
    public DbSet<DirectorPhotoReadModel> DirectorPhotos {get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfiguration(new MovieReadConfiguration());
        modelBuilder.ApplyConfiguration(new GenreReadConfiguration());
        modelBuilder.ApplyConfiguration(new DirectorReadConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewReadConfiguration());
        modelBuilder.ApplyConfiguration(new LikeReadConfiguration());
        modelBuilder.ApplyConfiguration(new PhotoReadConfiguration());
        modelBuilder.ApplyConfiguration(new MoviePhotoReadConfiguration());
        modelBuilder.ApplyConfiguration(new DirectorPhotoReadConfiguration());
    }
}