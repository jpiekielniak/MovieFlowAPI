using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Directors.Commands.CreateDirector;

internal sealed class CreateDirectorHandler(IDirectorRepository directorRepository)
    : IRequestHandler<CreateDirectorCommand, CreateDirectorResponse>
{
    public async Task<CreateDirectorResponse> Handle(CreateDirectorCommand command,
        CancellationToken cancellationToken)
    {
        var director = Director.Create(
            command.FirstName,
            command.LastName,
            command.DateOfBirth,
            command.Country
        );

        await directorRepository.AddAsync(director, cancellationToken);
        return new CreateDirectorResponse(director.Id);
    }
}