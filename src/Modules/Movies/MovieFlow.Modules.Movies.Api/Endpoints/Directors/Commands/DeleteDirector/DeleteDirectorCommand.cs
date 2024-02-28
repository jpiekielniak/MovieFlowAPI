namespace MovieFlow.Modules.Movies.Api.Endpoints.Directors.Commands.DeleteDirector;

internal record DeleteDirectorCommand(Guid DirectorId) : IRequest;