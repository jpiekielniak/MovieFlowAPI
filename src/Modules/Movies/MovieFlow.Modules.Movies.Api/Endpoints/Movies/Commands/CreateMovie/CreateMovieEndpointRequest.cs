using MovieFlow.Modules.Movies.Application.Movies.Commands.CreateMovie;

namespace MovieFlow.Modules.Movies.Api.Endpoints.Movies.Commands.CreateMovie;

internal class CreateMovieEndpointRequest
{
    [FromJson] public CreateMovieCommand Command { get; init; } = default!;
    public IFormFile Photo { get; init; }
}