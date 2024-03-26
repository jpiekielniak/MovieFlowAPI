using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read;

internal sealed class PhotoReadConfiguration : IEntityTypeConfiguration<PhotoReadModel>
{
    public void Configure(EntityTypeBuilder<PhotoReadModel> builder)
    {
        builder.HasKey(x => x.Id);
        
      
        builder.ToTable("Photos");
    }
}