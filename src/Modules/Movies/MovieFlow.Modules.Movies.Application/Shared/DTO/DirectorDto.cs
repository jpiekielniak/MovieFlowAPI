namespace MovieFlow.Modules.Movies.Application.Shared.DTO;

internal record DirectorDto(Guid Id, string FirstName, string LastName, List<string> PhotoUrl);