using MovieFlow.Modules.Users.Core.Users.Entities;

namespace MovieFlow.Modules.Users.Core.Users.Repositories;

internal interface IUserRepository
{
    Task<bool> UserExistsAsync(string email, string name);
    Task AddAsync(User user, CancellationToken cancellationToken);
    Task CommitAsync(CancellationToken cancellationToken);

    Task<User> GetByEmailAsync(string commandEmail);
}