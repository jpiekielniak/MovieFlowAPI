namespace MovieFlow.Modules.Movies.Application.Actors.Commands.DeleteActor;

internal record DeleteActorCommand(Guid ActorId) : IRequest;