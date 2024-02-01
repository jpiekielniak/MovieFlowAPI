namespace FilmFlow.Modules.Films.Application.Films.Queries.Browse.DTO;

internal record FilmDto(
    Guid Id,
    string Title,
    int ReleaseYear,
    double Rating,
    string Description);