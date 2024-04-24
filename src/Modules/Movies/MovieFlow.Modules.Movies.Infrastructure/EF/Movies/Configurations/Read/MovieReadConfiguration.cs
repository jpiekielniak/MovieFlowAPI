using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read;

internal sealed class MovieReadConfiguration : IEntityTypeConfiguration<MovieReadModel>
{
    public void Configure(EntityTypeBuilder<MovieReadModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Genres)
            .WithMany(x => x.Movies)
            .UsingEntity(j => j.ToTable("MovieGenres_Mapping"));

        builder.HasMany(x => x.Reviews)
            .WithOne(x => x.Movie)
            .HasForeignKey(x => x.MovieId);
        
        builder.HasMany(x => x.Actors)
            .WithMany(x => x.Movies)
            .UsingEntity(x => x.ToTable("ActorMovie"));

        builder.ToTable("Movies");
    }
}