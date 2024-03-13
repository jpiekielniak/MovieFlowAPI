using Microsoft.EntityFrameworkCore;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Entities;
using MovieFlow.Modules.Newsletters.Infrastructure.EF.Configurations.Write;

namespace MovieFlow.Modules.Newsletters.Infrastructure.EF.Context;

internal sealed class NewslettersWriteDbContext : DbContext
{
    private static string Schema = "newsletters";

    public DbSet<EmailSubscription> EmailSubscriptions { get; set; }

    public NewslettersWriteDbContext(DbContextOptions<NewslettersWriteDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfiguration(new EmailSubscriptionWriteConfiguration());
    }
}