using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read;

internal sealed class DirectorReadConfiguration : IEntityTypeConfiguration<DirectorReadModel>
{
    public void Configure(EntityTypeBuilder<DirectorReadModel> builder)
    {
        builder.HasKey(x => x.Id);

        builder.ToTable("Directors");
    }
}