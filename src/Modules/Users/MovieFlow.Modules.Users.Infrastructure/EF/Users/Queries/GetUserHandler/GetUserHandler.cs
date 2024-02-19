using MovieFlow.Modules.Users.Application.Users.Queries.DTO;
using MovieFlow.Modules.Users.Application.Users.Queries.Get;
using MovieFlow.Modules.Users.Core.Users.Exceptions;
using MovieFlow.Modules.Users.Infrastructure.EF.Context;
using MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.Read.Model;
using MovieFlow.Shared.Abstractions;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Queries.GetUserHandler;

internal sealed class GetUserHandler(UsersReadDbContext readDbContext)
    : IRequestHandler<GetUserQuery, UserDetailsDto?>
{
    private readonly DbSet<UserReadModel> _users = readDbContext.Users;

    public async Task<UserDetailsDto?> Handle(GetUserQuery query,
        CancellationToken cancellationToken)
    {
        var user = await _users
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == query.userId,
                cancellationToken)
            .NotNull(() => new UserNotFoundException(query.userId));

        return user?.AsDetailsDto();
    }
}