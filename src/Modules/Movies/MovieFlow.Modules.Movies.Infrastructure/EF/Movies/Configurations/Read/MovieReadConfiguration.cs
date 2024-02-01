using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read;

internal sealed class MovieReadConfiguration : IEntityTypeConfiguration<MovieReadModel>
{
    public void Configure(EntityTypeBuilder<MovieReadModel> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.ToTable("Movies");
    }
}