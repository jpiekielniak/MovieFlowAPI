namespace MovieFlow.Modules.Movies.Application.Directors.Queries.DTO;

internal record DirectorDetailsDto(
    Guid DirectorId,
    string FirstName,
    string LastName,
    DateTime DateOfBirth,
    string Country,
    List<string> DirectorPhotos
);