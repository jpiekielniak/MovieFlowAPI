using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read;

internal sealed class GenreReadConfiguration : IEntityTypeConfiguration<GenreReadModel>
{
    public void Configure(EntityTypeBuilder<GenreReadModel> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.ToTable("Genres");
    }
}