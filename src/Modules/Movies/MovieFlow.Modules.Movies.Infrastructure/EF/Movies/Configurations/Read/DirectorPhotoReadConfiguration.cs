using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read;

internal sealed class DirectorPhotoReadConfiguration : IEntityTypeConfiguration<DirectorPhotoReadModel>
{
    public void Configure(EntityTypeBuilder<DirectorPhotoReadModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("DirectorPhotos");
    }
}