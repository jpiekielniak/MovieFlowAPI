using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
        
        builder.Property<Rating>("Rating")
            .HasConversion(x => x.Value, x => new Rating(x))
            .HasColumnName("Rating")
            .IsRequired();

        builder.Property<CreatedAt>("CreatedAt")
            .HasConversion(x => x.Value, x => new CreatedAt(x))
            .HasColumnName("CreatedAt")
            .IsRequired();
        
        builder.Property<UpdatedAt>("UpdatedAt")
            .HasConversion(x => x.Value, x => new UpdatedAt(x))
            .HasColumnName("UpdatedAt")
            .IsRequired(false);

        builder.Property<EntityState>("State")
            .HasColumnName("State")
            .IsRequired();

        builder.ToTable("Movies");
    }
}