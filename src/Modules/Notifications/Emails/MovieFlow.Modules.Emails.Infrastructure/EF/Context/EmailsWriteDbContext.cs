using MovieFlow.Modules.Emails.Core.Emails.Entities;
using MovieFlow.Modules.Emails.Infrastructure.EF.Configuration.Write;

namespace MovieFlow.Modules.Emails.Infrastructure.EF.Context;

internal sealed class EmailsWriteDbContext : DbContext
{
    private static string Schema => "emails";
    public DbSet<Email> Emails { get; set; }

    public EmailsWriteDbContext(DbContextOptions<EmailsWriteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfiguration(new EmailWriteConfiguration());
    }
}