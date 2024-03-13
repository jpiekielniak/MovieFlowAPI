using MovieFlow.Modules.Newsletters.Core.Newsletters.Entities;

namespace MovieFlow.Modules.Newsletters.Core.Newsletters.Repositories;

internal interface IEmailSubscriptionsRepository
{
    Task AddAsync(EmailSubscription subscription, CancellationToken cancellationToken);
    Task<bool> CheckEmailExistsAsync(string email, CancellationToken cancellationToken);
    Task<List<string>> GetAllAsync(CancellationToken cancellationToken);
}