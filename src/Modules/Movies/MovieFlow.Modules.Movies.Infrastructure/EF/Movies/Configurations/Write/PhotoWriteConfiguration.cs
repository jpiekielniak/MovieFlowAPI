using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Write;

internal sealed class PhotoWriteConfiguration : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.FileName)
            .IsUnique();

        builder.Property(x => x.FileName)
            .IsRequired();

        builder.Property(x => x.Url)
            .IsRequired();

        builder.Property(x => x.Alt)
            .IsRequired();

        builder.Property(x => x.ContentType)
            .IsRequired();
        
        builder.ToTable("Photos");
    }
}