using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Entities;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Email;

namespace MovieFlow.Modules.Newsletters.Infrastructure.EF.Configurations.Write;

internal sealed class EmailSubscriptionWriteConfiguration : IEntityTypeConfiguration<EmailSubscription>
{
    public void Configure(EntityTypeBuilder<EmailSubscription> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.Email)
            .HasConversion(x => x.Value, x => new Email(x));

        builder.Property<DateTimeOffset>("CreatedAt")
            .IsRequired();

        builder.ToTable("EmailSubscriptions");
    }
}