namespace MovieFlow.Modules.Movies.Application.Directors.Commands.ChangeDirectorInformation;

internal record ChangeDirectorInformationCommand(
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string Country) : IRequest
{
    internal Guid DirectorId { get; init; }
}