using MovieFlow.Modules.Users.Core.Users.Entities;

namespace MovieFlow.Modules.Users.Core.Users.Repositories;

internal interface IRoleRepository
{
    Task<Role> GetAsync(string name, CancellationToken cancellationToken);
}