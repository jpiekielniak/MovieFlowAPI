using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Write;

internal sealed class LikeWriteConfiguration : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property<Guid>("UserId")
            .HasColumnName("UserId")
            .IsRequired();

        builder.Property<bool>("IsPositive")
            .IsRequired();

        builder.HasOne(x => x.Review)
            .WithMany(x => x.Likes)
            .HasForeignKey(x => x.ReviewId);

        builder.ToTable("Likes");
    }
}