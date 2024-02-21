using MovieFlow.Modules.Emails.Core.Emails.Entities;
using MovieFlow.Modules.Emails.Core.Emails.Repositories;
using MovieFlow.Modules.Emails.Infrastructure.EF.Contexts;

namespace MovieFlow.Modules.Emails.Infrastructure.EF.Emails.Repositories;

internal sealed class EmailRepository(
    EmailsWriteDbContext writeDbContext) : IEmailRepository
{
    private readonly DbSet<Email> _emails = writeDbContext.Emails;

    public async Task AddAsync(Email email, CancellationToken cancellationToken)
    {
        await _emails.AddAsync(email, cancellationToken);
        await CommitAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
        => await writeDbContext.SaveChangesAsync(cancellationToken);
}