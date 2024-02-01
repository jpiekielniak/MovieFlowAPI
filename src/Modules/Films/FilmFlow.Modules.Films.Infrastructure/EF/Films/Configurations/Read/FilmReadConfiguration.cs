using FilmFlow.Modules.Films.Infrastructure.EF.Films.Configurations.Read.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmFlow.Modules.Films.Infrastructure.EF.Films.Configurations.Read;

internal sealed class FilmReadConfiguration : IEntityTypeConfiguration<FilmReadModel>
{
    public void Configure(EntityTypeBuilder<FilmReadModel> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.ToTable("Films");
    }
}