namespace MovieFlow.Modules.Movies.Application.Movies.Queries.Get.DTO;

internal record MovieDetailsDto(
    Guid Id,
    string Title,
    double Rating,
    int ReleaseYear,
    string Description,
    List<GenreNameDto> Genres,
    DirectorDto Director);