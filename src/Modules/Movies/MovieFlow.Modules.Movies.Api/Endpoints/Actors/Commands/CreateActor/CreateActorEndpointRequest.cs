using MovieFlow.Modules.Movies.Application.Actors.Commands.CreateActor;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Actors.Commands.CreateActor;

internal sealed class CreateActorEndpointRequest
{
    [FromJson] public CreateActorCommand Command { get; init; } = default!;
    public IFormFile Photo { get; init; }
}