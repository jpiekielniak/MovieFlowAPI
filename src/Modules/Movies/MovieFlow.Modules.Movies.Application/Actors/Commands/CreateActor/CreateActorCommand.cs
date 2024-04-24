namespace MovieFlow.Modules.Movies.Application.Actors.Commands.CreateActor;

internal record CreateActorCommand(string FirstName, string LastName, DateTime DateOfBirth, string Country)
    : IRequest<CreateActorResponse>;