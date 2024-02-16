using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Content;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Rating;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Title;
using EntityState = MovieFlow.Shared.Abstractions.Kernel.EntityState;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Write;

internal sealed class ReviewWriteConfiguration : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property<Title>(x => x.Title)
            .HasConversion(x => x.Value, x => new Title(x))
            .HasColumnName("Title")
            .IsRequired();

        builder.Property<Content>(x => x.Content)
            .HasConversion(x => x.Value, x => new Content(x))
            .HasColumnName("Content")
            .IsRequired();

        builder.Property<Rating>(x => x.Rating)
            .HasConversion(x => x.Value, x => new Rating(x))
            .HasColumnName("Rating")
            .IsRequired();

        builder.Property<Guid>("UserId")
            .HasColumnName("UserId")
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

        builder.HasOne(x => x.Movie)
            .WithMany(x => x.Reviews)
            .HasForeignKey(x => x.MovieId);

        builder.ToTable("Reviews");
    }
}