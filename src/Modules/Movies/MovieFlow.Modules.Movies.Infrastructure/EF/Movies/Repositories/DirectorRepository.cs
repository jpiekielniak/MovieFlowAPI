using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Repositories;

internal sealed class DirectorRepository(MoviesWriteDbContext dbContext) : IDirectorRepository
{
    public async Task<Director?> GetAsync(Guid id, CancellationToken cancellationToken)
        => await dbContext.Directors.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
}