using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Directors;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Shared.Abstractions;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Directors.Commands.DeleteDirector;

internal sealed class DeleteDirectorHandler(IDirectorRepository directorRepository)
    : IRequestHandler<DeleteDirectorCommand>
{
    public async Task Handle(DeleteDirectorCommand command, CancellationToken cancellationToken)
    {
        var director = await directorRepository
            .GetAsync(command.DirectorId, cancellationToken)
            .NotNull(() => new DirectorNotFoundException(command.DirectorId));

        await directorRepository.DeleteAsync(director, cancellationToken);
    }
}