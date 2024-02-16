using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read;

internal sealed class LikeReadConfiguration : IEntityTypeConfiguration<LikeReadModel>
{
    public void Configure(EntityTypeBuilder<LikeReadModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("Likes");
    }
}