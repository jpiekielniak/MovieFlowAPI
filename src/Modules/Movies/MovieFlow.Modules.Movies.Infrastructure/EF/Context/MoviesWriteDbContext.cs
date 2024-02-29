using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Write;
using MovieFlow.Shared.Abstractions.Kernel;
using MovieFlow.Shared.Abstractions.Time;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Context;

internal class MoviesWriteDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<MoviePhoto> MoviePhotos { get; set; }
    private readonly IClock _clock;

    public MoviesWriteDbContext(DbContextOptions<MoviesWriteDbContext> options, IClock clock)
        : base(options) => _clock = clock;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("movies");
        modelBuilder.ApplyConfiguration(new MovieWriteConfiguration());
        modelBuilder.ApplyConfiguration(new GenreWriteConfiguration());
        modelBuilder.ApplyConfiguration(new DirectorWriteConfiguration());
        modelBuilder.ApplyConfiguration(new ReviewWriteConfiguration());
        modelBuilder.ApplyConfiguration(new LikeWriteConfiguration());
        modelBuilder.ApplyConfiguration(new PhotoWriteConfiguration());
        modelBuilder.ApplyConfiguration(new MoviePhotoWriteConfiguration());
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<Entity>())
        {
            if (entry.State == EntityState.Added)
                entry.Property<DateTimeOffset>("CreatedAt").CurrentValue = _clock.CurrentDateTimeOffset();

            if (entry.State is EntityState.Modified or EntityState.Deleted)
                entry.Property<DateTimeOffset?>("UpdatedAt").CurrentValue = _clock.CurrentDateTimeOffset();
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}