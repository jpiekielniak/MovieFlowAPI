using MovieFlow.Modules.Emails.Core.Emails.Entities;
using MovieFlow.Modules.Emails.Infrastructure.EF.Configuration.Write;

namespace MovieFlow.Modules.Emails.Infrastructure.EF.Contexts;

internal sealed class EmailsWriteDbContext : DbContext
{
    public DbSet<Email> Emails { get; set; }

    public EmailsWriteDbContext(DbContextOptions<EmailsWriteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("emails");
        modelBuilder.ApplyConfiguration(new EmailWriteConfiguration());
    }
}