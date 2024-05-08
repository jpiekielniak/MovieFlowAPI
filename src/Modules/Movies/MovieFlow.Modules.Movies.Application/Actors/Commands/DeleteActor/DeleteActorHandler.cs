using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Actors;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;

namespace MovieFlow.Modules.Movies.Application.Actors.Commands.DeleteActor;

internal sealed class DeleteActorHandler(IActorRepository actorRepository,
    IPhotoRepository photoRepository) : IRequestHandler<DeleteActorCommand>
{
    public async Task Handle(DeleteActorCommand command, CancellationToken cancellationToken)
    {
        var actor = await actorRepository
            .GetAsync(command.ActorId, cancellationToken)
            .NotNull(() => throw new ActorNotFoundException(command.ActorId));

        await actorRepository.DeleteAsync(actor, cancellationToken);
        await photoRepository.DeleteAsync(actor.Photos.SingleOrDefault(), cancellationToken);
    }
}