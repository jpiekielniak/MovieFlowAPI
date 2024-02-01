using FilmFlow.Modules.Films.Core.Films.Entities;
using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.CreatedAt;
using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.Description;
using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.Rating;
using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.ReleaseYear;
using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.Title;
using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.UpdatedAt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmFlow.Modules.Films.Infrastructure.EF.Films.Configurations.Write;

internal class FilmWriteConfiguration : IEntityTypeConfiguration<Film>
{
    public void Configure(EntityTypeBuilder<Film> builder)
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

        builder.ToTable("Films");
    }
}