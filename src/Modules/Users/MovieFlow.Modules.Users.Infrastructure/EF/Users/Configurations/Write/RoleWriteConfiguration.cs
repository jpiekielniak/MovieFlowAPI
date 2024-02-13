using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Name;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.Write;

internal class RoleWriteConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.HasIndex(x => x.Name)
            .IsUnique();

        builder.Property<Name>("Name")
            .HasConversion(
                x => x.Value,
                x => new Name(x))
            .IsRequired();

        builder.Property(x => x.Permissions)
            .HasConversion(x => string.Join(',', x), x => x.Split(',', StringSplitOptions.None));

        builder
            .Property(x => x.Permissions).Metadata.SetValueComparer(
                new ValueComparer<IEnumerable<string>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, next) => HashCode.Combine(a, next.GetHashCode()))));

        builder.ToTable("Roles");
    }
}