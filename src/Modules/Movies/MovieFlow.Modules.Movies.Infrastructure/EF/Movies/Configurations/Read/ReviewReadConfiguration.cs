using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read;

internal sealed class ReviewReadConfiguration : IEntityTypeConfiguration<ReviewReadModel>
{
    public void Configure(EntityTypeBuilder<ReviewReadModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Likes)
            .WithOne()
            .HasForeignKey(x => x.ReviewId);

        builder.ToTable("Reviews");
    }
}