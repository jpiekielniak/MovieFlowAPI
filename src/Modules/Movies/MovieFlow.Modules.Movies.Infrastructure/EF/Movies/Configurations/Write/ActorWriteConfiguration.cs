using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Country;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.FirstName;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.LastName;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Write;

internal sealed class ActorWriteConfiguration : IEntityTypeConfiguration<Actor>
{
    public void Configure(EntityTypeBuilder<Actor> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.FirstName)
            .HasConversion(x => x.Value, x => new FirstName(x))
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasConversion(x => x.Value, x => new LastName(x))
            .IsRequired();

        builder.Property(x => x.DateOfBirth)
            .IsRequired();

        builder.Property(x => x.Country)
            .HasConversion(x => x.Value, x => new Country(x));

        builder.HasMany(x => x.Movies)
            .WithMany(x => x.Actors);
    }
}