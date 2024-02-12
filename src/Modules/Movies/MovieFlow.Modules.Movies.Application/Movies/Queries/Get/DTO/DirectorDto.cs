namespace MovieFlow.Modules.Movies.Application.Movies.Queries.Get.DTO;

internal record DirectorDto(
    Guid DirectorId,
    string FirstName,
    string LastName);