using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieFlow.Modules.Users.Core.Entities;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Email;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Name;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Password;
using EntityState = MovieFlow.Shared.Abstractions.Kernel.EntityState;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.Write;

internal class UserWriteConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Name)
            .IsUnique();
        
        builder.Property<Name>("Name")
            .HasConversion(
                x => x.Value,
                x => new Name(x))
            .HasColumnName("Name")
            .IsRequired();

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property<Email>("Email")
            .HasConversion(
                x => x.Value,
                x => new Email(x))
            .HasColumnName("Email")
            .IsRequired();

        builder.Property<bool>("EmailConfirmed");

        builder.Property<DateTimeOffset?>("EmailConfirmedAt")
            .IsRequired(false);

        builder.Property<Password>("Password")
            .HasConversion(
                x => x.Value,
                x => new Password(x))
            .HasColumnName("Password")
            .IsRequired();

        builder.Property<DateTimeOffset?>("LastChangePasswordAt");

        builder.Property(x => x.IsActive);

        builder.Property<Guid>("RoleId")
            .IsRequired();

        builder.Property<DateTimeOffset>("CreatedAt")
            .HasColumnName("CreatedAt")
            .IsRequired();
        
        builder.Property<DateTimeOffset?>("UpdatedAt")
            .HasColumnName("UpdatedAt")
            .IsRequired(false);

        builder.Property<EntityState>("State")
            .HasColumnName("State")
            .IsRequired();

        builder.HasOne(x => x.Role)
            .WithMany(x => x.Users)
            .HasForeignKey(x => x.RoleId);

        builder.ToTable("Users");
    }
}