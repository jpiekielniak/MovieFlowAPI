using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Directors;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Directors.Commands.DeleteDirector;

internal sealed class DeleteDirectorHandler(IDirectorRepository directorRepository,
    IPhotoRepository photoRepository)
    : IRequestHandler<DeleteDirectorCommand>
{
    public async Task Handle(DeleteDirectorCommand command, 
        CancellationToken cancellationToken)
    {
        var director = await directorRepository
            .GetAsync(command.DirectorId, cancellationToken)
            .NotNull(() => new DirectorNotFoundException(command.DirectorId));

        await directorRepository.DeleteAsync(director, cancellationToken);
        await photoRepository.DeleteAsync(director.Photos.SingleOrDefault(), cancellationToken);
    }
}