namespace MovieFlow.Modules.Movies.Core.Movies.Exceptions.Actors;

internal class ActorNotFoundException(Guid actorId) : MovieFlowException($"Actor with id {actorId} not found.");