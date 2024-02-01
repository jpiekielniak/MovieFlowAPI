using FilmFlow.Modules.Films.Core.Films.Entities;
using FilmFlow.Modules.Films.Infrastructure.EF.Films.Configurations.Write;
using Microsoft.EntityFrameworkCore;

namespace FilmFlow.Modules.Films.Infrastructure.EF.Context;

internal class FilmsWriteDbContext : DbContext
{
    public DbSet<Film> Films { get; set; }
    
    public FilmsWriteDbContext(DbContextOptions<FilmsWriteDbContext> options) 
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("films");
        modelBuilder.ApplyConfiguration(new FilmWriteConfiguration());
    }

}