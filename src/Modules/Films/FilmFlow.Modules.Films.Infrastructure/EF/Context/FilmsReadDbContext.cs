using FilmFlow.Modules.Films.Infrastructure.EF.Films.Configurations.Read;
using FilmFlow.Modules.Films.Infrastructure.EF.Films.Configurations.Read.Model;
using Microsoft.EntityFrameworkCore;

namespace FilmFlow.Modules.Films.Infrastructure.EF.Context;

internal sealed class FilmsReadDbContext(DbContextOptions<FilmsReadDbContext> options) 
    : DbContext(options)
{
    public DbSet<FilmReadModel> Films { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("films");
        modelBuilder.ApplyConfiguration(new FilmReadConfiguration());
    }
}