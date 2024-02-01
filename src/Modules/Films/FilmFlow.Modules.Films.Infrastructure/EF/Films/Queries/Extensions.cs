using FilmFlow.Modules.Films.Application.Films.Queries.Browse;
using FilmFlow.Modules.Films.Application.Films.Queries.Browse.DTO;
using FilmFlow.Modules.Films.Infrastructure.EF.Films.Configurations.Read.Model;

namespace FilmFlow.Modules.Films.Infrastructure.EF.Films.Queries;

internal static class Extensions
{
    public static FilmDto AsFilmDto(this FilmReadModel film)
        => new(
            film.Id,
            film.Title,
            film.ReleaseYear,
            film.Rating,
            film.Description);
}