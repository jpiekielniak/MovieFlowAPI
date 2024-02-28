using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Repositories;

internal sealed class DirectorRepository(MoviesWriteDbContext dbContext) : IDirectorRepository
{
    private readonly DbSet<Director> _directors = dbContext.Directors;

    public async Task<Director> GetAsync(Guid id, CancellationToken cancellationToken)
        => await _directors.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task AddAsync(Director director, CancellationToken cancellationToken)
    {
        await _directors.AddAsync(director, cancellationToken);
        await CommitAsync(cancellationToken);
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
        => await dbContext.SaveChangesAsync(cancellationToken);

    public async Task DeleteAsync(Director director, CancellationToken cancellationToken)
    {
        _directors.Remove(director);
        await CommitAsync(cancellationToken);
    }
}