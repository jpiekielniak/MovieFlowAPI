using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Modules.Users.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Repositories;

internal sealed class UserRepository(UsersWriteDbContext dbContext) : IUserRepository
{
    private readonly DbSet<User> _users = dbContext.Users;

    public async Task<bool> UserExistsAsync(string email, string name)
        => await _users.AnyAsync(u => u.Email == email && u.Name == name);

    public async Task AddAsync(User user, CancellationToken cancellationToken)
    {
        await _users.AddAsync(user, cancellationToken);
        await CommitAsync(cancellationToken);
    }

    public async Task<User> GetByEmailAsync(string email)
        => await _users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(u => u.Email == email);

    public async Task<User> GetAsync(Guid userId, CancellationToken cancellationToken)
        => await _users.SingleOrDefaultAsync(u => u.Id == userId, cancellationToken);

    public async Task DeleteAsync(User user, CancellationToken cancellationToken)
    {
        _users.Remove(user);
        await CommitAsync(cancellationToken);
    }

    public async Task UpdateAsync(User user, CancellationToken cancellationToken)
    {
        _users.Update(user);
        await CommitAsync(cancellationToken);
    }

    private async Task CommitAsync(CancellationToken cancellationToken)
        => await dbContext.SaveChangesAsync(cancellationToken);
}