using Microsoft.EntityFrameworkCore;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Entities;
using MovieFlow.Modules.Newsletters.Core.Newsletters.Repositories;
using MovieFlow.Modules.Newsletters.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Newsletters.Infrastructure.EF.EmailSubscriptions.Repositories;

internal sealed class EmailSubscriptionRepository(NewslettersWriteDbContext writeDbContext)
    : IEmailSubscriptionsRepository
{
    private readonly DbSet<EmailSubscription> _emailSubscriptions = writeDbContext.EmailSubscriptions;

    public async Task AddAsync(EmailSubscription subscription, CancellationToken cancellationToken)
    {
        await _emailSubscriptions.AddAsync(subscription, cancellationToken);
        await writeDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> CheckEmailExistsAsync(string email, CancellationToken cancellationToken)
        => await _emailSubscriptions.AnyAsync(x => x.Email == email, cancellationToken);
}