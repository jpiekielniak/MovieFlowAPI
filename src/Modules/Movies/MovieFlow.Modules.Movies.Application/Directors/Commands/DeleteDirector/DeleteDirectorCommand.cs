namespace MovieFlow.Modules.Movies.Application.Directors.Commands.DeleteDirector;

internal record DeleteDirectorCommand(Guid DirectorId) : IRequest;