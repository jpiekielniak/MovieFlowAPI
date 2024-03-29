using MovieFlow.Modules.Users.Core.Users.Entities;

namespace MovieFlow.Modules.Users.Core.Users.Repositories;

internal interface IUserRepository
{
    Task<bool> UserExistsAsync(string email, string name, CancellationToken cancellationToken);
    Task AddAsync(User user, CancellationToken cancellationToken);

    Task<User> GetByEmailAsync(string commandEmail);
    Task<User> GetAsync(Guid userId, CancellationToken cancellationToken);
    public Task DeleteAsync(User user, CancellationToken cancellationToken);
    Task UpdateAsync(User user, CancellationToken cancellationToken);
}