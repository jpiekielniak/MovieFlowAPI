using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Country;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.CreatedAt;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.FirstName;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.LastName;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.UpdatedAt;
using EntityState = MovieFlow.Shared.Abstractions.Kernel.EntityState;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Write;

internal class DirectorWriteConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property<FirstName>("FirstName")
            .HasConversion(x => x.Value, x => new FirstName(x))
            .HasColumnName("FirstName")
            .IsRequired();

        builder.Property<LastName>("LastName")
            .HasConversion(x => x.Value, x => new LastName(x))
            .HasColumnName("LastName")
            .IsRequired();

        builder.Property<DateTime>("DateOfBirth")
            .HasColumnName("DateOfBirth")
            .IsRequired();

        builder.Property<Country>("Country")
            .HasConversion(x => x.Value, x => new Country(x))
            .HasColumnName("Country")
            .IsRequired();
        
        builder.Property<CreatedAt>("CreatedAt")
            .HasConversion(x => x.Value, x => new CreatedAt(x))
            .HasColumnName("CreatedAt")
            .IsRequired();
        
        builder.Property<UpdatedAt>("UpdatedAt")
            .HasConversion(x => x.Value, x => new UpdatedAt(x))
            .HasColumnName("UpdatedAt")
            .IsRequired(false);

        builder.Property<EntityState>("State")
            .HasColumnName("State")
            .IsRequired();

        builder.HasMany(x => x.Movies)
            .WithOne(x => x.Director)
            .HasForeignKey(x => x.DirectorId);

        builder.ToTable("Directors");
    }
}