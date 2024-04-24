using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read;

internal sealed class ActorReadConfiguration : IEntityTypeConfiguration<ActorReadModel>
{
    public void Configure(EntityTypeBuilder<ActorReadModel> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.ToTable("Actors");
    }
}