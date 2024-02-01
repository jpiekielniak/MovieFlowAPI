using Microsoft.EntityFrameworkCore;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Write;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Context;

internal class MoviesWriteDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
    
    public MoviesWriteDbContext(DbContextOptions<MoviesWriteDbContext> options) 
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Movies");
        modelBuilder.ApplyConfiguration(new MovieWriteConfiguration());
    }

}