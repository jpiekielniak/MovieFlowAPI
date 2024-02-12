using MovieFlow.Modules.Movies.Core.Movies.Entities;
using EntityState = MovieFlow.Shared.Abstractions.Kernel.EntityState;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Write;

internal class GenreWriteConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(f => f.Id);
        
        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property<string>("Name")
            .HasColumnName("Name")
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

        builder.ToTable("Genres");
    }
}