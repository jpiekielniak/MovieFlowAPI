using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Write;

internal sealed class DirectorPhotoWriteConfiguration : IEntityTypeConfiguration<DirectorPhoto>
{
    public void Configure(EntityTypeBuilder<DirectorPhoto> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.DirectorId)
            .IsRequired();

        builder.Property(x => x.PhotoId)
            .IsRequired();
        
        builder.ToTable("DirectorPhotos");
    }
}