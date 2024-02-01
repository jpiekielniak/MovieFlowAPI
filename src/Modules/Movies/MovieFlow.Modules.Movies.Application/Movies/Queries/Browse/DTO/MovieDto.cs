namespace MovieFlow.Modules.Movies.Application.Movies.Queries.Browse.DTO;

internal record MovieDto(
    Guid Id,
    string Title,
    int ReleaseYear,
    double Rating,
    string Description);