using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Actors.Commands.CreateActor;

internal sealed class CreateActorHandler(IActorRepository actorRepository)
    : IRequestHandler<CreateActorCommand, CreateActorResponse>
{
    public async Task<CreateActorResponse> Handle(CreateActorCommand command,
        CancellationToken cancellationToken)
    {
        var actor = Actor.Create(
            command.FirstName,
            command.LastName,
            command.DateOfBirth,
            command.Country);

        await actorRepository.AddAsync(actor, cancellationToken);

        return new CreateActorResponse(actor.Id);
    }
}