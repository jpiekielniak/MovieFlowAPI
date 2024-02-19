using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.CreatedAt;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Description;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Rating;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.ReleaseYear;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Title;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.UpdatedAt;
using EntityState = MovieFlow.Shared.Abstractions.Kernel.EntityState;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Write;

internal class MovieWriteConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property<Title>("Title")
            .HasConversion(x => x.Value, x => new Title(x))
            .HasColumnName("Title")
            .IsRequired();
        
        builder.Property<Description>("Description")
            .HasConversion(x => x.Value, x => new Description(x))
            .HasColumnName("Description")
            .IsRequired();

        builder.Property<ReleaseYear>("ReleaseYear")
            .HasConversion(x => x.Value, x => new ReleaseYear(x))
            .HasColumnName("ReleaseYear")
            .IsRequired();

        builder.Property<DateTimeOffset>("CreatedAt")
            .HasColumnName("CreatedAt")
            .IsRequired();
        
        builder.Property<DateTimeOffset?>("UpdatedAt")
            .HasColumnName("UpdatedAt")
            .IsRequired(false);

        builder.Property<EntityState>("State")
            .HasColumnName("State")
            .IsRequired();

        builder.HasMany(x => x.Genres)
            .WithMany(x => x.Movies)
            .UsingEntity(j => j.ToTable("MovieGenres_Mapping"));
        

        builder.ToTable("Movies");
    }
}