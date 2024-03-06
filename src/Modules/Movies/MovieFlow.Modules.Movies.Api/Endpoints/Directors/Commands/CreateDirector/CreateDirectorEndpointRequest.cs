using MovieFlow.Modules.Movies.Application.Directors.Commands.CreateDirector;
using Swashbuckle.AspNetCore.JsonMultipartFormDataSupport.Attributes;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Directors.Commands.CreateDirector;

internal sealed class CreateDirectorEndpointRequest
{
    [FromJson] public CreateDirectorCommand Command { get; init; } = default!;
    public IFormFile Photo { get; init; }
}