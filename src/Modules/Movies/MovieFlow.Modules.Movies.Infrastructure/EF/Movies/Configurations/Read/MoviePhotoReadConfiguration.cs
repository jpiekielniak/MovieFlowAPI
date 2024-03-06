using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read;

internal sealed class MoviePhotoReadConfiguration : IEntityTypeConfiguration<MoviePhotoReadModel>
{
    public void Configure(EntityTypeBuilder<MoviePhotoReadModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("MoviePhotos");
    }
}