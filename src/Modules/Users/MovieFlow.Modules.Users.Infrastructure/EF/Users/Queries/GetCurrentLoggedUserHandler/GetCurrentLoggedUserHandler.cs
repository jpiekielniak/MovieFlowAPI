using MovieFlow.Modules.Users.Application.Users.Queries.DTO;
using MovieFlow.Modules.Users.Application.Users.Queries.GetCurrentLoggedUser;
using MovieFlow.Modules.Users.Core.Users.Exceptions.Users;
using MovieFlow.Modules.Users.Infrastructure.EF.Context;
using MovieFlow.Shared.Abstractions;
using MovieFlow.Shared.Abstractions.Contexts;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Queries.GetCurrentLoggedUserHandler;

internal sealed class GetCurrentLoggedUserHandler(IContext context,
    UsersReadDbContext readDbContext) : IRequestHandler<GetCurrentLoggedUserQuery, UserDetailsDto>
{
    public async Task<UserDetailsDto> Handle(GetCurrentLoggedUserQuery query,
        CancellationToken cancellationToken)
    {
        var user = await readDbContext.Users
            .AsNoTracking()
            .Include(x => x.Role)
            .SingleOrDefaultAsync(x => x.Id == context.Identity.Id, cancellationToken)
            .NotNull(() => new UserNotFoundException(context.Identity.Id));

        return user.AsDetailsDto();
    }
}