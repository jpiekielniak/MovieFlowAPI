using MovieFlow.Modules.Users.Application.Users.Queries.DTO;
using MovieFlow.Modules.Users.Application.Users.Queries.GetCurrent;
using MovieFlow.Modules.Users.Core.Users.Exceptions;
using MovieFlow.Modules.Users.Infrastructure.EF.Context;
using MovieFlow.Shared.Abstractions;
using MovieFlow.Shared.Abstractions.Contexts;

namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Queries.GetCurrentUserHandler;

internal sealed class GetCurrentUserHandler(
    IContext context,
    UsersReadDbContext readDbContext) : IRequestHandler<GetCurrentUserQuery, UserDetailsDto>
{
    public async Task<UserDetailsDto> Handle(GetCurrentUserQuery query,
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