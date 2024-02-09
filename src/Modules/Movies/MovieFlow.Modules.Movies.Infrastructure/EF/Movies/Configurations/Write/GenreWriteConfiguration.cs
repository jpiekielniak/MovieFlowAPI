using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.CreatedAt;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.UpdatedAt;
using EntityState = MovieFlow.Shared.Abstractions.Kernel.EntityState;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Write;

internal class GenreWriteConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property<string>("Name")
            .HasColumnName("Name")
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

        builder.ToTable("Genres");
    }
}