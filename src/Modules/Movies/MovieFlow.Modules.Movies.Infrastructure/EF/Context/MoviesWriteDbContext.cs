using Microsoft.EntityFrameworkCore;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Write;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.CreatedAt;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.UpdatedAt;
using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Context;

internal class MoviesWriteDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    private readonly IClock _clock;
    
    public MoviesWriteDbContext(DbContextOptions<MoviesWriteDbContext> options, IClock clock) 
        : base(options)
    {
        _clock = clock;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("movies");
        modelBuilder.ApplyConfiguration(new MovieWriteConfiguration());
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in ChangeTracker.Entries<Movie>())
        {
            if (entry.State == EntityState.Added)
                entry.Property<CreatedAt>("CreatedAt").CurrentValue = _clock.CurrentDateTimeOffset();
            
            if (entry.State == EntityState.Modified)
                entry.Property<UpdatedAt>("UpdatedAt").CurrentValue = _clock.CurrentDateTimeOffset();

        }
        
        return base.SaveChangesAsync(cancellationToken);
    }

}