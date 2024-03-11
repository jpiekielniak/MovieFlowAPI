using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Write;

internal sealed class MoviePhotoWriteConfiguration : IEntityTypeConfiguration<MoviePhoto>
{
    public void Configure(EntityTypeBuilder<MoviePhoto> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasOne(x => x.Movie)
            .WithMany(m => m.MoviePhotos)
            .HasForeignKey(x => x.MovieId);
        
        builder.ToTable("MoviePhotos");
    }
}