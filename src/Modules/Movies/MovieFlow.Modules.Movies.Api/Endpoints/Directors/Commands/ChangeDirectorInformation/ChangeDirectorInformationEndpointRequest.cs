using MovieFlow.Modules.Movies.Application.Directors.Commands.ChangeDirectorInformation;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Directors.Commands.ChangeDirectorInformation;

internal sealed class ChangeDirectorInformationEndpointRequest
{
    [FromRoute(Name = "directorId")] public Guid DirectorId { get; init; }
    [FromBody] public ChangeDirectorInformationCommand Command { get; init; } = default!;
}