using MovieFlow.Modules.Emails.Core.Emails.Entities;
using MovieFlow.Modules.Emails.Core.Emails.Enums;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Recipient;

namespace MovieFlow.Modules.Emails.Infrastructure.EF.Configuration.Write;

internal sealed class EmailWriteConfiguration : IEntityTypeConfiguration<Email>
{
    public void Configure(EntityTypeBuilder<Email> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property<Recipient>("Recipient")
            .HasConversion(x => x.Value, x => new Recipient(x))
            .HasColumnName("Recipient")
            .IsRequired();

        builder.Property<string>("Subject")
            .HasColumnName("Subject")
            .IsRequired(false);

        builder.Property<string>("Message")
            .HasColumnName("Message")
            .IsRequired(false);

        builder.Property<DateTimeOffset>("SentAt")
            .HasColumnName("SentAt")
            .IsRequired();

        builder.Property<EmailMessageStatus>("Status")
            .HasConversion<string>()
            .HasColumnName("Status")
            .IsRequired();

        builder.ToTable("Emails");
    }
}