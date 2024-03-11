namespace MovieFlow.Modules.Movies.Application.Directors.Commands.CreateDirector;

internal record CreateDirectorCommand(string FirstName, string LastName, DateTime DateOfBirth, string Country)
    : IRequest<CreateDirectorResponse>
{
    internal IFormFile Photo { get; init; }
}