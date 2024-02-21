using MovieFlow.Modules.Emails.Core.Emails.Entities;

namespace MovieFlow.Modules.Emails.Core.Emails.Repositories;

internal interface IEmailRepository
{
    Task AddAsync(Email email, CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);
}