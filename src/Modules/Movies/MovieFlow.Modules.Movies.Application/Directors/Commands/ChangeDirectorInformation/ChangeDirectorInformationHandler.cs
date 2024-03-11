using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Directors;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Directors.Commands.ChangeDirectorInformation;

internal sealed class ChangeDirectorInformationHandler(IDirectorRepository directorRepository)
    : IRequestHandler<ChangeDirectorInformationCommand>
{
    public async Task Handle(ChangeDirectorInformationCommand command, CancellationToken cancellationToken)
    {
        var director = await directorRepository
            .GetAsync(command.DirectorId, cancellationToken)
            .NotNull(() => new DirectorNotFoundException(command.DirectorId));

        director.ChangeInformation(
            command.FirstName,
            command.LastName,
            command.DateOfBirth,
            command.Country
        );

        await directorRepository.CommitAsync(cancellationToken);
    }
}