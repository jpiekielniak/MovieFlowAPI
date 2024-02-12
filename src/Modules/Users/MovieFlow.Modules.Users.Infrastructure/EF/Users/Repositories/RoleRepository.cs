using Microsoft.EntityFrameworkCore;
using MovieFlow.Modules.Users.Core.Users.Entities;
using MovieFlow.Modules.Users.Core.Users.Repositories;
using MovieFlow.Modules.Users.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Repositories;

internal sealed class RoleRepository(UsersWriteDbContext dbContext) : IRoleRepository
{
    private readonly DbSet<Role> _roles = dbContext.Roles;

    public async Task<Role> GetAsync(string name, CancellationToken cancellationToken)
        => await _roles.SingleOrDefaultAsync(x => x.Name == name, cancellationToken);
}